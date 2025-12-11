using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using RPF.CustomItems.Keycards;
using RPF.CustomItems.weapons;
using RPF.Events.CustomWeapon;

//Put new Handler for version 1.3.0
namespace RPF.Events.CustomItems
{
    public class CustomItemsHandler
    {
        public void Register()
        {
            //Added New Keycard for Custom Roles and resolved Bug not registering Items for version 2.0.0.
            if (!Main.Instance.Config.CustomItems) return;
            CustomItem.RegisterItems();
            Exiled.CustomItems.API.Features.CustomWeapon.RegisterItems();
            new OmniKeycard().Register();
            new ManagerKeycard().Register();
            new ChiefKeycard().Register();
            new ExpertKeycard().Register();
            new ProKeycard().Register();
            new TechKeycard().Register();
            new MediGun().Register();
            new EMP_Device().Register();
            new SuperAdrenaline().Register();
            new AimBotGun().Register();
            new CidKeycard().Register();
            //New Cage Weapon!
            new CageWeapon().Register();
        }

        public void Unregister()
        {
            CustomItem.UnregisterItems();
            EMP_Device.UnregisterItems();
            SuperAdrenaline.UnregisterItems();
            OmniKeycard.UnregisterItems();
            MediGun.UnregisterItems();
            AimBotGun.UnregisterItems();
            ManagerKeycard.UnregisterItems();
            ChiefKeycard.UnregisterItems();
            ExpertKeycard.UnregisterItems();
            ProKeycard.UnregisterItems();
            TechKeycard.UnregisterItems();
            CidKeycard.UnregisterItems();
            CageWeapon.UnregisterItems();
        }
    }    
}
