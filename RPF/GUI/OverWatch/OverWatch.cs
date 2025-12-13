using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using RueI.API;
using RueI.API.Elements;

namespace RPF.GUI.OverWatch
{
    /// <summary>
    /// Added an OverWatch GUI that shows player information when they become Overwatch.
    /// </summary>
    public class Overwatch
    {
        private void OnChangingRole(ChangingRoleEventArgs ev)
        {
            RueDisplay display = RueDisplay.Get(ev.Player);
            Tag timerTag = new Tag("Timer");

            var spectatedApiPlayer = ev.Player.CurrentSpectatingPlayers.FirstOrDefault();
            if (spectatedApiPlayer == null)
            {
                Log.Warn("[RPF - CustomGUI]: Nessun giocatore osservato.");
                display.Remove(timerTag);
                return;
            }

            Player player = Player.Get(spectatedApiPlayer);

            Log.Info("[RPF - CustomGUI]: Player changing role at overwatch detected.");

            if (ev.NewRole == RoleTypeId.Overwatch)
            {
                DynamicElement dynamicTimer = new DynamicElement(180, () =>
                {
                    string overwatch = "<color=blue>OverWatch System:</color>\n" +
                                       $"NickName: {player.Nickname}\n" +
                                       $"ID: {player.Id}\n" +
                                       $"Inventory: {player.Inventory}";
                    return overwatch;
                });
                display.Show(timerTag, dynamicTimer);
                return;
            }

            display.Remove(timerTag);
        }

        public void Register()
        {
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
        }

        public void Unregister()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
        }
    }
}