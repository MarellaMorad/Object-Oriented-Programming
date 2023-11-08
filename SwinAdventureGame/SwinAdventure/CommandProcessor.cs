using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor : Command
    {
        private List<Command> _commands = new List<Command>();

        private LookCommand _lookCommand = new LookCommand();
        private MoveCommand _moveCommand = new MoveCommand();
        private TransferCommand _transferCommand = new TransferCommand();
        //private PutCommand _putCommand = new PutCommand();
        //private TakeCommand _takeCommand = new TakeCommand();
        private QuitCommand _quitCommand = new QuitCommand();

        public CommandProcessor() : base(new string[] {"command"}) //adding the _commands to the list
        {
            _commands.Add(_lookCommand);
            _commands.Add(_moveCommand);
            _commands.Add(_transferCommand);
            //_commands.Add(_putCommand);
            //_commands.Add(_takeCommand);
            _commands.Add(_quitCommand);
        }

        public override string Execute(Player p, string[] text)
        {
            foreach(Command c in _commands)
            {
                if(c.AreYou(text[0])) //identify the command
                {
                    return c.Execute(p, text); //execute the command based on the text passed in
                }
            }

            string search = "";

            foreach(string txt in text)
            {
                search = search + txt + " ";
            }

            return "I don't understand " + search.TrimEnd(); //if the command is not found / error in input _commands (not move nor 
        }
    }
}
