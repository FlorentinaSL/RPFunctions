using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using RPF.CustomRoles;
using RPF.Events._035Spawn;
using RPF.Events._914Event;
using RPF.Events.BroadCast;
using RPF.Events.CustomAnnunci;
using RPF.Events.CustomItems;
using RPF.Events.Misc;
using RPF.Events.RPSCP;
using RPF.Events.TeslaGate;
using RPF.Events.OnPlayerJoin;
using RPF.GUI;
using UnityEngine;

namespace RPF
{
    //Copyright RPFunctions & RPF-API
    //All rights reserved
    public class Main : Plugin<Config>
    {
        private BroadCastBreach _broadcast;
        private Scp096ElevatorRestriction _scp096ElevatorRestriction;
        private NoDoorsFor106 _noDoorsFor10;
        private NoElevatorFor939 _noElevatorFor939;
        private TeslaConditions _teslaGate;
        private Kill914 _kill914;
        private CustomRoleHandler _customRoleHandler;
        private CustomItemsHandler _customItemsHandler;
        private PlayerJoin _playerJoin;
        private Annunci _annunci;
        // Added new GUI'S. And Fixed Bug for Timer (2.1.0)
        private CustomGUIHandler _customGUIHandler;
        //Added new 035 interactive Mask! (2.1.1)
        private SpawnRecall _035spawnRecall;
        public static Main Instance { get; private set; }
        public FemurBreakerEvent FemurBreaker { get; private set; }
        public override string Name { get; } = "RPFunctions";
        public override string Author { get; } = "Mr.Cat - #Per purgatorium <3";
        public override string Prefix { get; } = "rpf";
        public override Version Version { get; } = new Version(2, 1, 1);
        //New Verision Exiled (From 9.8.1 -> 9.10.2).
        public override Version RequiredExiledVersion { get; } = new Version(9, 10, 2);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override void OnEnabled()
        {
            Instance = this;
            
            CustomItem.RegisterItems();
            CustomWeapon.RegisterItems();
            CustomRole.RegisterRoles(true, this);
            
            _broadcast = new BroadCastBreach();
            _broadcast.Register();

            _noDoorsFor10 = new NoDoorsFor106();
            _noDoorsFor10.RegisterEvents();

            _noElevatorFor939 = new NoElevatorFor939();
            _noElevatorFor939.RegisterEvents();

            _scp096ElevatorRestriction = new Scp096ElevatorRestriction();
            _scp096ElevatorRestriction.RegisterEvents();

            _teslaGate = new RPF.Events.TeslaGate.TeslaConditions();
            _teslaGate.Register();

            FemurBreaker = new Events.Misc.FemurBreakerEvent(Config);
            FemurBreaker.Register();

            _kill914 = new Kill914();
            _kill914.Register();

            _customRoleHandler = new CustomRoleHandler();
            _customRoleHandler.Register();

            //Added Keycard For version 2.0.0
            _customItemsHandler = new CustomItemsHandler();
            _customItemsHandler.Register();

            _playerJoin = new PlayerJoin();
            _playerJoin.Register();

            _annunci = new Annunci();
            _annunci.Register();

            _customGUIHandler = new CustomGUIHandler();
            _customGUIHandler.Register();

            _035spawnRecall = new SpawnRecall();
            _035spawnRecall.Register();
            
            Log.Info("[RPF - Ruoli Custom] Status Ruoli: [VALID]");
            Log.Info("[RPF - Armi Custom] Status Armi: [VALID]");
            Log.Info("========= [Purgatorium | RPF | Normal] =========\n" +
                     "RPF Status: [VALID]\n" +
                     $"Author: {Author}\n" +
                     $"Version: {Version}\n" +
                     "=================================================");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _customItemsHandler.Unregister();
            _broadcast.Unregister();
            _noDoorsFor10.UnregisterEvents();
            _kill914.Unregister();
            _noElevatorFor939.UnregisterEvents();
            _scp096ElevatorRestriction.UnregisterEvents();
            _teslaGate.Unregister();
            _customRoleHandler.Unregister();
            FemurBreaker?.Unregister();
            FemurBreaker = null;
            _playerJoin.UnRegister();
            _annunci.UnRegister();
            _customGUIHandler.UnRegister();
            _035spawnRecall.UnRegister();
            
            Debug.Log("[RPF - Internal] disabilitato");
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            Debug.Log("[RPF - Internal] ricaricato");
            base.OnReloaded();
        }
        
    }
}
