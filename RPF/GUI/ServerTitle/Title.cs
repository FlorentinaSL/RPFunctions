using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using RueI.API;
using RueI.API.Elements;
using RueI.Utils;


namespace RPF.GUI.ServerTitle;

public class Title
{
    private void OnVerified(VerifiedEventArgs ev) 
    {
        Log.Info("[RPF - CustomGUI]: Nuovo giocatore! Dando hint...");
        Timing.RunCoroutine(HandlerHint(ev.Player), Segment.Update);
      
    }

    private IEnumerator<float> HandlerHint(Player player)
    {
        while (player.IsConnected)
        {
            RueDisplay rueDisplay = RueDisplay.Get(player);
            Tag Title = new Tag("Title");
            rueDisplay.Show(Title, new BasicElement(100, Main.Instance.Config.MessaggeHintTitle));
            yield return Timing.WaitForSeconds(1);
        }
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