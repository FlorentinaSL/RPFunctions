using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace RPF.CustomItems.Keycards;

public class OmniKeycard : CustomKeycard
{
    public override uint Id { get; set; } = 142;
    public override string Name { get; set; } = "05-X Keycard";
    public override string Description { get; set; } = "OmniCarta Presa dal'05-X.";
    public override float Weight { get; set; } = 1.5f;
    public override SpawnProperties SpawnProperties { get; set; }
    public override string KeycardLabel { get; set; } = "OmniCarta-05X";
    public override Color32? KeycardLabelColor { get; set; } = new Color32(255,255,255,255);
    public override Color32? KeycardPermissionsColor { get; set; } = new Color32(0, 0, 0, 0);
    public override string KeycardName { get; set; } = "OmniCarta-05X";
    public override string SerialNumber { get; set; } = "05-X";
    public override ItemType Type { get; set; } = ItemType.KeycardCustomSite02;
    public override KeycardPermissions Permissions { get; set; } =
        KeycardPermissions.AlphaWarhead |
        KeycardPermissions.ArmoryLevelThree |
        KeycardPermissions.ArmoryLevelOne |
        KeycardPermissions.ArmoryLevelTwo |
        KeycardPermissions.Checkpoints |
        KeycardPermissions.ExitGates |
        KeycardPermissions.Intercom |
        KeycardPermissions.ScpOverride;

    protected override void OnAcquired(Player player, Item item, bool displayMessage)
    {
        player.Broadcast(10,Main.Instance.Config.OnAcquiringOmni);
        base.OnAcquired(player, item, displayMessage);
    }

    protected override void OnPickingUp(PickingUpItemEventArgs ev)
    {
        ev.Player.Broadcast(10, Main.Instance.Config.OnPickingOmni);
        base.OnPickingUp(ev);
    }

    protected override void SetupKeycard(Keycard keycard)
    {
        base.SetupKeycard(keycard);
    }
    protected override void SubscribeEvents()
    {
        Log.Info("[RPF - CustomKeycard]: Carta 05-X registrata SUCCESS");
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Log.Info("[RPF - CustomKeycard]: Carta 05-X de-registrata SUCCESS");
        base.UnsubscribeEvents();
    }
}