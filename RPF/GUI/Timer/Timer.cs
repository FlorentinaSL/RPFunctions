using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using RueI.API;
using RueI.API.Elements;

namespace RPF.GUI.Timer;

public class Timer
{
    private void onChanging(ChangingRoleEventArgs ev)
    {
        RueDisplay display = RueDisplay.Get(ev.Player);
        Tag timerTag = new Tag("Timer");
        
        if (ev.NewRole == RoleTypeId.Spectator)
        {
            Log.Info("[RPF - CustomGUI]: New Spectator joined, showing timer.");
            
            DynamicElement dynamicTimer = new DynamicElement(150, () =>
            {
                string msg = Main.Instance.Config.MessaggeHintTimer
                    .Replace("{players}", Player.List.Count().ToString())
                    .Replace("{specs}", Player.List.Count(p => p.Role == RoleTypeId.Spectator).ToString());

                return msg;
            });

            display.Show(timerTag, dynamicTimer);
            return;
        }
        display.Remove(timerTag);
    }
    
    public void Register()
    {
        Exiled.Events.Handlers.Player.ChangingRole += onChanging;
    }

    public void UnRegister()
    {
        Exiled.Events.Handlers.Player.ChangingRole -= onChanging;
    }
}