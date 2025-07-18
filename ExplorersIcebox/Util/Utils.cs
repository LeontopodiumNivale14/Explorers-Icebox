using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Interface.Colors;
using ECommons.Automation.NeoTaskManager;
using ECommons.DalamudServices.Legacy;
using ECommons.Logging;
using ECommons.Reflection;
using ECommons.Throttlers;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorersIcebox.Util;

/// <summary>
/// Misc of utilities that don't really belong in one place
/// </summary>
public class Utils
{
    public static bool HasPlugin(string name) => DalamudReflector.TryGetDalamudPlugin(name, out _, false, true);
    public static TaskManagerConfiguration TaskConfig => new(timeLimitMS: 10 * 60 * 3000, abortOnTimeout: false);

    public static void TargetgameObject(IGameObject? gameObject)
    {
        var x = gameObject;
        if (x == null || x.IsTarget())
        {
            return;
        }
        else
        {
            if (EzThrottler.Throttle($"Throttle Targeting {x.Name}"))
            {
                Svc.Targets.SetTarget(x);
                PluginLog.Information($"Setting the target to {x.Name}");
            }
        }
    }
    internal static bool TryGetObjectByDataId(ulong dataId, out IGameObject? gameObject) => (gameObject = Svc.Objects.OrderBy(PlayerHelper.GetDistanceToPlayer).FirstOrDefault(x => x.DataId == dataId)) != null;
    internal static bool TryGetObjectByGameObjectId(ulong gameObjectId, out IGameObject? gameObject) => (gameObject = Svc.Objects.OrderBy(PlayerHelper.GetDistanceToPlayer).FirstOrDefault(x => x.GameObjectId == gameObjectId)) != null;
    internal static unsafe void InteractWithObject(IGameObject? gameObject)
    {
        try
        {
            if (gameObject == null || !gameObject.IsTargetable)
                return;
            var gameObjectPointer = (GameObject*)gameObject.Address;
            TargetSystem.Instance()->InteractWithObject(gameObjectPointer, false);
        }
        catch (Exception ex)
        {
            Svc.Log.Info($"InteractWithObject: Exception: {ex}");
        }
    }

    public static void FancyCheckmark(bool enabled)
    {
        float columnWidth = ImGui.GetColumnWidth();  // Get column width
        float rowHeight = ImGui.GetTextLineHeightWithSpacing();  // Get row height

        Vector2 iconSize = ImGui.CalcTextSize($"{FontAwesome.Cross}"); // Get icon size
        float iconWidth = iconSize.X;
        float iconHeight = iconSize.Y;

        float cursorX = ImGui.GetCursorPosX() + (columnWidth - iconWidth) * 0.5f;
        float cursorY = ImGui.GetCursorPosY() + (rowHeight - iconHeight) * 0.5f;

        cursorX = Math.Max(cursorX, ImGui.GetCursorPosX()); // Prevent negative padding
        cursorY = Math.Max(cursorY, ImGui.GetCursorPosY());

        ImGui.SetCursorPos(new Vector2(cursorX, cursorY));

        if (!enabled)
        {
            FontAwesome.Print(ImGuiColors.DalamudRed, FontAwesome.Cross);
        }
        else if (enabled)
        {
            FontAwesome.Print(ImGuiColors.HealerGreen, FontAwesome.Check);
        }
    }

    public static unsafe void OpenPlayerSearch(uint commandId)
    {
        UIModule.Instance()->ExecuteMainCommand(commandId);
    }

    public static unsafe void ShowText(int position, string text)
    {
        UIModule.Instance()->ShowText(position, text);
    }

    public static unsafe bool IsNodeVisible(string addonName, params int[] ids)
    {
        var ptr = Svc.GameGui.GetAddonByName(addonName, 1);
        if (ptr == nint.Zero)
            return false;

        var addon = (AtkUnitBase*)ptr;
        var node = GetNodeByIDChain(addon->GetRootNode(), ids);
        return node != null && node->IsVisible();
    }

    public static unsafe string GetNodeText(string addonName, params int[] nodeNumbers)
    {

        var ptr = Svc.GameGui.GetAddonByName(addonName, 1);

        var addon = (AtkUnitBase*)ptr;
        var uld = addon->UldManager;

        AtkResNode* node = null;
        var debugString = string.Empty;
        for (var i = 0; i < nodeNumbers.Length; i++)
        {
            var nodeNumber = nodeNumbers[i];

            var count = uld.NodeListCount;

            node = uld.NodeList[nodeNumber];
            debugString += $"[{nodeNumber}]";

            // More nodes to traverse
            if (i < nodeNumbers.Length - 1)
            {
                uld = ((AtkComponentNode*)node)->Component->UldManager;
            }
        }

        if (node->Type == NodeType.Counter)
            return ((AtkCounterNode*)node)->NodeText.ToString();

        var textNode = (AtkTextNode*)node;
        return textNode->NodeText.GetText();
    }

    private static unsafe AtkResNode* GetNodeByIDChain(AtkResNode* node, params int[] ids)
    {
        if (node == null || ids.Length <= 0)
            return null;

        if (node->NodeId == ids[0])
        {
            if (ids.Length == 1)
                return node;

            var newList = new List<int>(ids);
            newList.RemoveAt(0);

            var childNode = node->ChildNode;
            if (childNode != null)
                return GetNodeByIDChain(childNode, [.. newList]);

            if ((int)node->Type >= 1000)
            {
                var componentNode = node->GetAsAtkComponentNode();
                var component = componentNode->Component;
                var uldManager = component->UldManager;
                childNode = uldManager.NodeList[0];
                return childNode == null ? null : GetNodeByIDChain(childNode, [.. newList]);
            }

            return null;
        }

        //check siblings
        var sibNode = node->PrevSiblingNode;
        return sibNode != null ? GetNodeByIDChain(sibNode, ids) : null;
    }
}
