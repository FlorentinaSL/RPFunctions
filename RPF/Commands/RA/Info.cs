using System;
using CommandSystem;

namespace RPF.Commands.RA
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class InfoCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            
            response = "==================================\n";
            response += "        RPFunctions (Purgatorium)\n    ";
            response += "Plugin Made by Mr.Cat\n";
            response += "==================================";
            return true;
        }

        public string Command => "RPF";
        public string[] Aliases => [ "rpf" ];
        public string Description => "Shows RP functions info";
    }
    
}