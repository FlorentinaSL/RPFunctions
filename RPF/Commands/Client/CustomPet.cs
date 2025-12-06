using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CommandSystem;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using ProjectMER.Features.Extensions;
using RPF_API.API.CustomPet;
using UnityEngine;

namespace RPF.Commands.Client;

[CommandHandler(typeof(ClientCommandHandler))]
public class CustomPet : ICommand
{
    private readonly Dictionary<Player, Npc> pets = new();
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        Player player = Player.Get(sender);
        if (arguments.Count < 1)
        {
            response = "Metti un tipo di ruolo per il pet!";
            return false;
        }

        string roleName = arguments.At(0);
        if (!Enum.TryParse(roleName, true, out RoleTypeId role))
        {
            response = $"Ruolo non valido: {roleName}";
            return false;
        }
        
        Npc npc = Npc.Spawn(
            name: $"Pet di {player.Nickname}",
            role: role,
            position: player.Position
            );
        pets[player] = npc;
        Timing.RunCoroutine(CheckIfdie(player));
        Timing.CallDelayed(0.5f, () =>
        {
            npc.BadgeHidden = true;
            npc.Scale = new Vector3(0.5f, 0.5f, 0.5f);
            npc.Follow(player);
        });
        response = $"Pettino creato per {player.Nickname}!";
        return true;
    }

    private IEnumerator<float> CheckIfdie(Player player)
    {
        if (!pets.TryGetValue(player, out Npc npc))
            yield break;
        
        yield return Timing.WaitForSeconds(1f);
        
        while (player.IsAlive && npc != null && npc.IsAlive)
        {
            yield return Timing.WaitForSeconds(1f);
        }
        
        npc?.Destroy();
        pets.Remove(player);

        Log.Info($"Il pet del player {player.Nickname} è stato rimosso.");
    }
    
    public string Command { get; } = "creapet";
    public string[] Aliases { get; } = [];
    public string Description { get; } = "Crea Il pet al giocatore assegnato.";
    public string Permission { get; } = "rpf.vip";
}