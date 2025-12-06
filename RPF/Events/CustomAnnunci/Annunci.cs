using System.Threading.Tasks;
using Exiled.API.Features;
using Random = System.Random;

namespace RPF.Events.CustomAnnunci;

public class Annunci
{
    private bool running = false;
    private Random random = new Random();

    private void OnRoundStarted()
    {
        if (Main.Instance.Config.IsEnabledAnnunci != true) return;
        running = true;
        Log.Info("[RPF - AnnunciC] Sistema Random Attivato (Inizio Round).");
        annunci();
    }
    
    private async void annunci()
    {
        while (running == true)
        {
            int attesa = random.Next(10_000, 120_000);
            await Task.Delay(attesa);

            if (!running) break;
            Map.Broadcast(7, Main.Instance.Config.AnnuncioContenuto);
        }
    }

    public void Register()
    {
        Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
    }

    public void UnRegister()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
    }
}