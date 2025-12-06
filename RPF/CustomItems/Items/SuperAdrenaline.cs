using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace RPF.Events.CustomItems
{
    public class SuperAdrenaline : CustomItem
    {
        public override uint Id { get; set; } = 201;
        public override string Name { get; set; } = "Silent Adrenaline";
        public override string Description { get; set; } = "Ti dà un Random Effect";
        public override float Weight { get; set; } = 1.5f;
        public override ItemType Type { get; set; } = ItemType.Adrenaline;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 5,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint()
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside914
                }
            }
        };

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickup;
            Exiled.Events.Handlers.Player.UsingItem += OnUsing;
            Debug.Log($"Item {Name} Subscribed");
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickup;
            Exiled.Events.Handlers.Player.UsingItem -= OnUsing;
            Debug.Log($"Item {Name} Unsubscribed");
            base.UnsubscribeEvents();
        }

        private void OnPickup(PickingUpItemEventArgs ev)
        {
            //patched: In 1.1.0
            if (!Check(ev.Pickup)) return;
            ev.Player.ShowHint("Hai preso una SuperAdrenaline!");
        }

        public void OnUsing(UsingItemEventArgs ev)
        {
            ev.Player.ApplyRandomEffect(); 
            Log.Debug($"{ev.Player.Nickname} usato la superAdrenaline");
        }
    }
}