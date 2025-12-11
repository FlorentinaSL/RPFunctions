using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;
using RueI.API;
using RueI.API.Elements;

namespace RPF.GUI.OverWatch;

/// <summary>
/// Added an OverWatch GUI that shows player information when they become Overwatch.
/// </summary>
public class Overwatch
{
    private void OnChangingRole(ChangingRoleEventArgs ev)
    {
        RueDisplay display = RueDisplay.Get(ev.Player);
        Tag timerTag = new Tag("Timer");
        Player player = Player.Get(ev.Player.CurrentSpectatingPlayers.FirstOrDefault());
        
        Log.Info("[RPF - CustomGUI]: Player changing role at overwatch detected.");
        if (ev.NewRole == RoleTypeId.Overwatch)
        {
            DynamicElement dynamicTimer = new DynamicElement(180, () =>
            {
                string overwatch = "<color=blue>OverWatch System:</color>\n" +
                                   $"NickName: {player.Nickname}\n" +
                                   $"ID: {ev.Player.Id}\n" +
                                   $"Inventory: \n{player.Inventory}";
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
