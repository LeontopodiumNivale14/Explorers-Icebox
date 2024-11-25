/*
 * This file is used to import all the necessary namespaces and classes that are used in the plugin.
 * This file is then imported in ALL the files in the plugin.
 *
 * you never have to worry about importing the same namespaces in every file. Especially usefull für utility classes.
 */

global using CSFramework = FFXIVClientStructs.FFXIV.Client.System.Framework.Framework;
global using Callback = ECommons.Automation.Callback;
global using Dalamud.Interface.Colors;
global using Dalamud.Interface.Utility;
global using Dalamud.Interface.Windowing;
global using Dalamud.Interface;
global using Dalamud.Plugin;
global using ECommons.DalamudServices.Legacy;
global using ECommons.DalamudServices;
global using ECommons.ImGuiMethods;
global using ECommons.Logging;
global using ECommons.Schedulers;
global using ECommons;
global using ImGuiNET;
global using System.Collections.Generic;
global using System.Linq;
global using System.Numerics;
global using System.Runtime.InteropServices;
global using System.Text;
global using System.Threading.Tasks;
global using System;
global using static ECommons.GenericHelpers;

global using static IslandLeveling.Util.IslandData.IslandAmounts;
global using static IslandLeveling.Util.IslandData.IslandIDs;
global using static IslandLeveling.Util.IslandData.IslandWorkshop;
global using static IslandLeveling.Util.IslandData.IslandSend;
global using static IslandLeveling.Util.IslandData.IslandSell;
global using static IslandLeveling.Util.IslandData.IslandMics;
