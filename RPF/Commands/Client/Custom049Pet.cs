using System;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Features;
using RPF_API.API.CustomPet;

namespace RPF.Commands.Client;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Custom049Pet : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        Player player = Player.Get(sender);
        SpawnPet.SpawnCustomPet049(player);
        response = "creating pet...";
        return true;
    }

    public string Command { get; } = "custom049";
    public string[] Aliases { get; } = [];
    public string Description { get; } = "create a custom pet for 049.";
}