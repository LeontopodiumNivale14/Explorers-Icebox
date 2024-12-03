using Dalamud.Game.ClientState.Objects.Types;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using Lumina.Excel.Sheets;

namespace ExplorersIcebox.Util
{
    internal class TargetUtil
    {
        internal static bool TryGetObjectByDataId(uint dataId, out IGameObject? gameObject) => (gameObject = Svc.Objects.OrderBy(GetDistanceToPlayer).FirstOrDefault(x => x.DataId == dataId)) != null;
        internal static unsafe void InteractWithObject(IGameObject? gameObject)
        {
            try
            {
                if (gameObject == null || !gameObject.IsTargetable)
                    return;
                var gameObjectPointer = (FFXIVClientStructs.FFXIV.Client.Game.Object.GameObject*)gameObject.Address;
                TargetSystem.Instance()->InteractWithObject(gameObjectPointer, false);
            }
            catch (Exception ex)
            {
                Svc.Log.Info($"InteractWithObject: Exception: {ex}");
            }
        }
    }
}
