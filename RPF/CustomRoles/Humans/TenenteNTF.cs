using System.Collections.Generic;
using CommandSystem.Commands.RemoteAdmin;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using UnityEngine;

namespace RPF.CustomRoles.Humans
{
    public class TenenteNTF : CustomRole
    {
        public override uint Id { get; set; } = 110;
        public override int MaxHealth { get; set; } = 120;
        public override string Name { get; set; } = "Tenente NTF";
        public override string Description { get; set; } = "Tenente NTF con la pistola Cage Spawner.";
        public override string CustomInfo { get; set; } = "Tenente NTF";
        public override RoleTypeId Role { get; set; } = RoleTypeId.NtfCaptain;
        public override float SpawnChance { get; set; } = 100;
        
        public override List<string> Inventory { get; set; } = new List<string>()
        {
            $"{ItemType.KeycardMTFCaptain}",
            "Cage-Spawner",
            "MediGun",
            "COM15",
            "9x19mm",
            "Medkit",
            "Flashlight",
            "Radio"
        };

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint()
                {
                    Chance = 100,
                    Location = SpawnLocationType.InsideSurfaceNuke
                }
            }
        };
        

        protected override void SubscribeEvents()
        {
            Debug.Log($"Role {Name} subscribed");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Debug.Log($"Role {Name} unsubscribed");
            base.UnsubscribeEvents();
        }

        public override void AddRole(Player player)
        {
            //Patched: in 1.2.0
            base.AddRole(player);
            player.Broadcast(10, "Sei un Tenente NTF.");
        }
        
    }
}
    


