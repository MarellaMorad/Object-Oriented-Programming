using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] {"quit"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            return "Good bye";
        }
    }
}
