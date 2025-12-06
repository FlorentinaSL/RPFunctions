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
            response = "Il player è null oppure non è il sender.";
            return false;
        }

        Vector3 pos = new Vector3(
            player.Position.x,
            player.Position.y,
            player.Position.z
            );
        
        response = $"Ecco le coordinate: {pos}";
        return true;
    }

    public string Command { get; } = "posizione";
    public string[] Aliases { get; } = [];
    public string Description { get; } = "Da le coordinate di dove il giocatore si trova <3";
}