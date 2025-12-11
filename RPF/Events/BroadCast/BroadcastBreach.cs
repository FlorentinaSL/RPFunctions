using System;
using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using Cassie = Exiled.API.Features.Cassie;
using Log = Exiled.API.Features.Log;
using Map = Exiled.API.Features.Map;

namespace RPF.Events.BroadCast
{
    public class BroadCastBreach
    {
        private void FlickerAllLights()
        {
            try
            {
                Map.TurnOffAllLights(10f);
                Door.LockAll(20, DoorLockType.Lockdown079);
                Cassie.Message(Main.Instance.Config.AnnoucementMessage, isNoisy: false, isSubtitles: true);
            }
            catch (Exception ex)
            {
                Log.Error($"[FlickerLights] Error: {ex}");
            }
        }

        public void OnRoundStarted()
        {
            if (!Main.Instance.Config.StartAnnoucement) return;
            Log.Info("[RPF - BroadCast]: Round Started, starting broadcast...");
            FlickerAllLights();
        }

        public void Register()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        }

        public void Unregister()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
    }
}