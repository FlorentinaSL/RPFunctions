using System;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Features;

namespace RPF.Commands.RA;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class Purgatorium : ICommand
{
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        var player = Player.Get(sender);
        response = "ViVa PuRgAtOrIuM!!!";
        player.Broadcast(10, "");
        return true;
    }

    public string Command { get; } = "purgatorium";
    public string[] Aliases { get; } = [ "purga" ];
    public string Description { get; } = "easteregg";
}