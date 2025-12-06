using RPF_API.API._035Event;

namespace RPF.Events._035Spawn;

public class SpawnRecall
{
    private void OnRoundStarted()
    {
        EventMask.SpawnMask();
        MaskCageSpawn.SpawnCage035();
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