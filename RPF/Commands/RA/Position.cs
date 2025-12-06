using System;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;

namespace RPF.Commands.RA;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Position : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        Player player = Player.Get(sender);
        if (player == null)
        {
            response = "Il player is null.";
            return false;
        }

        Vector3 pos = new Vector3(
            player.Position.x,
            player.Position.y,
            player.Position.z
            );
        
        response = $"Here are the coordinates: {pos}";
        return true;
    }

    public string Command { get; } = "coordinate";
    public string[] Aliases { get; } = [];
    public string Description { get; } = "gives the coordinates of the player who send the command <3";
}