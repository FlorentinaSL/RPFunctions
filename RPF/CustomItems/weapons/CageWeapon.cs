using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
//New RPF API.
using RPF_API.API._173Cage;
using UnityEngine;

namespace RPF.CustomItems.weapons;

[CustomItem(ItemType.GunCOM15)]
public class CageWeapon : Exiled.CustomItems.API.Features.CustomWeapon
{
    private bool cageSpawned = false;
    
    public override uint Id { get; set; } = 142;
    public override string Name { get; set; } = "Cage-Spawner";
    public override string Description { get; set; } = "Create a cage around SCP-173 when hurting it.";
    public override float Weight { get; set; } = 1.5f;
    public override Vector3 Scale { get; set; } = new Vector3(1f, 1f, 1f);
    public override SpawnProperties SpawnProperties { get; set; }
    

    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
        Exiled.Events.Handlers.Player.Hurting += OnHurting;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        Exiled.Events.Handlers.Player.Hurting -= OnHurting;
        base.UnsubscribeEvents();
    }

    protected override void OnHurting(HurtingEventArgs ev)
    {
        if (!cageSpawned && ev.Player.Role.Type == RoleTypeId.Scp173)
        {
            CageEvent.SpawnCage();
            cageSpawned = true;
        }
        base.OnHurting(ev);
    }

    public void OnRoundStarted()
    {
        cageSpawned = false;
    }
}