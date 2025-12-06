using System.ComponentModel;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace RPF
{
    public class Config : IConfig
    {
        [Description("----------------------- Pl Main -----------------------")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("----------------------- SCP RP EVENTS ----------------------")]
        public string ScpRpFunctions096 { get; set; } = "Non puoi utilizzare gli ascensori quando 106 è in rage!";
        public bool enable_106_functions { get; set; } = true;
        public string ScpRpFunctions106 { get; set; } = "Non puoi utilizzare le porte!";
        public bool enable_096_functions { get; set; } = true;
        public string ScpRpFunctions939 { get; set; } = "Non puoi utilizzare gli ascensori!";
        public bool enable_939_functions { get; set; } = true;
        
        [Description("----------------------- FemurBreaker -----------------------")]
        public bool EnableFemurBreaker { get; set; } = true;
        public string femur_command { get; set; } = "femur";
        public int GeneratorsRequired { get; set; } = 3;
        public bool OnlyHumansCanTrigger { get; set; } = true;
        public int FemurBreakerDelay { get; set; } = 8000;

        public static string FemurBreakerCassie { get; set; } = "<b><color=red>Femur Breaker attivato . . .</color></b>";
        
        [Description("------------------------ Overload Command ---------------------")]
        public string OverloadCommand { get; set; } = "Overload";
        public bool EnableOverloadCommand { get; set; } = true;
        public string Overload079Cassie { get; set; } = "Overload... Completed...";
        
        [Description("------------------------ Scientist Command ------------------------")]
        public string ScientistInstructions { get; set; } = "Vai all'uscita! Ecco una keycard per farti uscire!";

        [Description("------------------------- BradCastBreach Main ---------------------")]
        public bool Start_Annoucment { get; set; } = true;
        
        [Description("------------------------- Tesla Conditions -------------------------")]
        public bool TeslaConditions { get; set; } = true;
        [Description("------------------------- Custom Roles & Items ----------------------")]
        public bool CustomRoles { get; set; } = true;
        public bool CustomItems { get; set; } = true;

        [Description("------------------------- Player Join -------------------------")]
        public bool IsEnabledMessage { get; set; } = true;
        public string MessaggeJoin { get; set; } = "<b><color=purple>Benvenuto su purgatorium RP!</color></b>";

        [Description("------------------------- Annunci Random -------------------------")]
        public bool IsEnabledAnnunci { get; set; } = false;
        public string AnnuncioContenuto { get; set; } = "<color=red>Non sei nel discord?! Perchè non ti unisci subito!</color>";

        [Description("------------------------- Custom Keycards (NON TOCCARE) -------------------------")]
        public string OnAcquiringOmni { get; set; } = "Hai ottenuto la Keycard Omni!";
        public string OnPickingOmni { get; set; } = "Hai raccolto la Keycard Omni.";

        public string OnAcquiringChief { get; set; } = "Hai ottenuto la Keycard Chief!";
        public string OnPickingChief { get; set; } = "Hai raccolto la Keycard Chief.";

        public string OnAcquiringCid { get; set; } = "Hai ottenuto la Keycard CID!";
        public string OnPickingCid { get; set; } = "Hai raccolto la Keycard CID.";

        public string OnAcquiringExpert { get; set; } = "Hai ottenuto la Keycard Expert!";
        public string OnPickingExpert { get; set; } = "Hai raccolto la Keycard Expert.";

        public string OnAcquiringPro { get; set; } = "Hai ottenuto la Keycard Pro!";
        public string OnPickingPro { get; set; } = "Hai raccolto la Keycard Pro.";

        public string OnAcquiringManager { get; set; } = "Hai ottenuto la Keycard Manager!";
        public string OnPickingManager { get; set; } = "Hai raccolto la Keycard Manager.";

        public string OnAcquiringTech { get; set; } = "Hai ottenuto la Keycard Tech!";
        public string OnPickingTech { get; set; } = "Hai raccolto la Keycard Tech.";

        [Description("------------------------- Custom GUI {player} e {specs} come alias. -------------------------")]
        //Gradient :0
        public string MessaggeHintTimer { get; set; } = "<b><color=#4bbfe2ff>Giocatori</color>:</b> {players} <b>| <color=#050eefff>Spettatori</color>:</b> {specs}";
        public string MessaggeHintTitle { get; set; } = "<color=#7402ED>P</color><color=#6E02ED>u</color><color=#6802ED>r</color><color=#6202ED>g</color><color=#5C02ED>a</color><color=#5602ED>t</color><color=#5002ED>o</color><color=#4A02ED>r</color><color=#4402ED>i</color><color=#3E02ED>u</color><color=#3802ED>m</color> <color=#2C02ED>R</color><color=#2602ED>P</color>";
        
    }
}