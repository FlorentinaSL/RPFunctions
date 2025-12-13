using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using RPF_API.API.FemurBreaker;
using UnityEngine;

namespace RPF.Commands.Client
{
    //Old femur breaker
    [CommandHandler(typeof(ClientCommandHandler))]
    public class OldFemurActivator : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
        {
            Room room = Room.Get(RoomType.Hcz106);
            var pos = room.Position;
                
            if (!Main.Instance.Config.EnableFemurBreaker)
            {
                response = "Femur Breaker is disabled in config.";
                return false;
            }
            if (Player.List.All(p => p.Role != RoleTypeId.Scp106))
            {
                response = "There is no SCP-106 in the round.";
                return false;
            }
            Npc npc = Npc.Spawn(
                name: "Femur-Tester",
                role: RoleTypeId.ClassD,
                position: room.Position
                );
            Action handler = null;
            handler = () =>
            {
                npc.Destroy();
                Femur.OnFemurAnimationFinished -= handler;
            };
            Femur.OnFemurAnimationFinished += handler;
            Femur.FemurSpawn();
            response = "Femur Breaker Activated!";
            return true;
        }

        public string Command { get; } = Main.Instance.Config.FemurCommand;
        public string[] Aliases { get; } = [ "femur" ];
        public string Description { get; } = "Activates the femur breaker.";
    }
}
