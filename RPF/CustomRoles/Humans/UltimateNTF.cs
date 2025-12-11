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
    public class UltimateNTF : CustomRole
    {
        public override uint Id { get; set; } = 110;
        public override int MaxHealth { get; set; } = 120;
        public override string Name { get; set; } = "Ultimate NTF";
        public override string Description { get; set; } = "Ultimate NTF with the Cage Spawner.";
        public override string CustomInfo { get; set; } = "Ultimate NTF NTF";
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
            // Added check Patch: in 2.2.1
            if (DecontaminationState.Remain1Minute != null)
            {
                SpawnProperties = null;
            }
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
            player.Broadcast(10, "you are an Ultimate NTF.");
        }
        
    }
}
    


