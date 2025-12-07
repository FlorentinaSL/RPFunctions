using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace RPF.Events.OnPlayerJoin;

public class PlayerJoin
{
    private void OnVerified(VerifiedEventArgs ev)
    {
        if (Main.Instance.Config.IsEnabledMessage != true) return;
        ev.Player.Broadcast(10, Main.Instance.Config.MessaggeJoin);
        Log.Info("[RPF - PlayerJoin] New Player Joined");
    }

    public void Register()
    {
        Exiled.Events.Handlers.Player.Verified += OnVerified;
    }

    public void UnRegister()
    {
        Exiled.Events.Handlers.Player.Verified -= OnVerified;
    }
}