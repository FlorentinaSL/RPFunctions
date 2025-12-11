using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using RPF.CustomRoles.Humans;
using RPF.Events.CustomRoles.Humans;

//Put new Handler for version 1.3.0
namespace RPF.CustomRoles
{
    public class CustomRoleHandler
    {
        public void Register()
        {
            if (Main.Instance.Config.CustomRoles != true) return;
            CustomRole.RegisterRoles(true, Main.Instance);
            new SiteManager().Register();
            new O5X().Register();
            new Chief_Guard().Register();
            new CI_CLASS_D().Register();
            new Expert_Guard().Register();
            new Scientist_Pro().Register();
            new Tech_Pro().Register();
            new UltimateNTF().Register();
        }

        public void Unregister()
        {
            CustomRole.UnregisterRoles();
            SiteManager.UnregisterRoles();
            O5X.UnregisterRoles();
            Chief_Guard.UnregisterRoles();
            CI_CLASS_D.UnregisterRoles();
            Expert_Guard.UnregisterRoles();
            Scientist_Pro.UnregisterRoles();
            Tech_Pro.UnregisterRoles();
            UltimateNTF.UnregisterRoles();
        }
    }
}

