using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace RPF.CustomItems.Keycards;

public class ExpertKeycard : CustomKeycard
{
    public override uint Id { get; set; } = 145;
    public override string Name { get; set; } = "Expert-Keycard";
    public override string Description { get; set; } = "Expert Guard Keycard for that role";
    public override float Weight { get; set; } = 1.5f;
    public override SpawnProperties SpawnProperties { get; set; }
    public override string KeycardLabel { get; set; } = "Expert-Keycard";
    public override Color32? KeycardLabelColor { get; set; } = new Color32(255,255,255,255);
    public override Color32? KeycardPermissionsColor { get; set; } = new Color32(128, 128, 128, 255);
    public override string KeycardName { get; set; } = "Expert-Keycard";
    public override string SerialNumber { get; set; } = "Expert";
    public override ItemType Type { get; set; } = ItemType.KeycardCustomSite02;

    public override KeycardPermissions Permissions { get; set; } =
        KeycardPermissions.ArmoryLevelOne |
        KeycardPermissions.ArmoryLevelTwo |
        KeycardPermissions.Checkpoints |
        KeycardPermissions.ExitGates;

    protected override void OnAcquired(Player player, Item item, bool displayMessage)
    {
        player.Broadcast(10,Main.Instance.Config.OnAcquiringExpert);
        base.OnAcquired(player, item, displayMessage);
    }

    protected override void OnPickingUp(PickingUpItemEventArgs ev)
    {
        ev.Player.Broadcast(10, Main.Instance.Config.OnPickingExpert);
        base.OnPickingUp(ev);
    }

    protected override void SetupKeycard(Keycard keycard)
    {
        base.SetupKeycard(keycard);
    }
    protected override void SubscribeEvents()
    {
        Log.Info("[RPF - CustomKeycard]: Keycard Expert registered SUCCESS");
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Log.Info("[RPF - CustomKeycard]: Keycard Expert un-registered SUCCESS");
        base.UnsubscribeEvents();
    }
}