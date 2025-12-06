using System.ComponentModel;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace RPF
{
    public class Config : IConfig
    {
        [Description("----------------------- Plugin Main -----------------------")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("----------------------- SCP RP EVENTS ----------------------")]
        public string ScpRpFunctions096 { get; set; } = "You cannot use elevators when 106 is in rage!";
        public bool enable_106_functions { get; set; } = true;

        public string ScpRpFunctions106 { get; set; } = "You cannot use doors!";
        public bool enable_096_functions { get; set; } = true;

        public string ScpRpFunctions939 { get; set; } = "You cannot use elevators!";
        public bool enable_939_functions { get; set; } = true;
        
        [Description("----------------------- FemurBreaker -----------------------")]
        public bool EnableFemurBreaker { get; set; } = true;
        public string femur_command { get; set; } = "femur";
        public int GeneratorsRequired { get; set; } = 3;
        public bool OnlyHumansCanTrigger { get; set; } = true;
        public int FemurBreakerDelay { get; set; } = 8000;

        public static string FemurBreakerCassie { get; set; } = "<b><color=red>Femur Breaker activated . . .</color></b>";
        
        [Description("------------------------ Overload Command ---------------------")]
        public string OverloadCommand { get; set; } = "Overload";
        public bool EnableOverloadCommand { get; set; } = true;
        public string Overload079Cassie { get; set; } = "Overload... Completed...";
        
        [Description("------------------------ Scientist Command ------------------------")]
        public string ScientistInstructions { get; set; } = "Go to the exit! Here is a keycard to help you escape!";

        [Description("------------------------- Breach Broadcast Main ---------------------")]
        public bool Start_Annoucment { get; set; } = true;
        
        [Description("------------------------- Tesla Conditions -------------------------")]
        public bool TeslaConditions { get; set; } = true;

        [Description("------------------------- Custom Roles & Items ----------------------")]
        public bool CustomRoles { get; set; } = true;
        public bool CustomItems { get; set; } = true;

        [Description("------------------------- Player Join -------------------------")]
        public bool IsEnabledMessage { get; set; } = true;
        public string MessaggeJoin { get; set; } = "<b><color=purple>Welcome to MyServer!</color></b>";

        [Description("------------------------- Random Announcements -------------------------")]
        public bool IsEnabledAnnunci { get; set; } = false;
        public string AnnuncioContenuto { get; set; } = "<color=red>Not in the Discord yet?! Why not join now!</color>";

        [Description("------------------------- Custom Keycards -------------------------")]
        public string OnAcquiringOmni { get; set; } = "You have obtained the Omni Keycard!";
        public string OnPickingOmni { get; set; } = "You picked up the Omni Keycard.";

        public string OnAcquiringChief { get; set; } = "You have obtained the Chief Keycard!";
        public string OnPickingChief { get; set; } = "You picked up the Chief Keycard.";

        public string OnAcquiringCid { get; set; } = "You have obtained the CID Keycard!";
        public string OnPickingCid { get; set; } = "You picked up the CID Keycard.";

        public string OnAcquiringExpert { get; set; } = "You have obtained the Expert Keycard!";
        public string OnPickingExpert { get; set; } = "You picked up the Expert Keycard.";

        public string OnAcquiringPro { get; set; } = "You have obtained the Pro Keycard!";
        public string OnPickingPro { get; set; } = "You picked up the Pro Keycard.";

        public string OnAcquiringManager { get; set; } = "You have obtained the Manager Keycard!";
        public string OnPickingManager { get; set; } = "You picked up the Manager Keycard.";

        public string OnAcquiringTech { get; set; } = "You have obtained the Tech Keycard!";
        public string OnPickingTech { get; set; } = "You picked up the Tech Keycard.";

        [Description("------------------------- Custom GUI {player} and {specs} as aliases -------------------------")]
        public string MessaggeHintTimer { get; set; } = "<b><color=#4bbfe2ff>Players</color>:</b> {players} <b>| <color=#050eefff>Spectators</color>:</b> {specs}";
        public string MessaggeHintTitle { get; set; } = "MyServer (Modify in Config!)";

    }
}
