using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            //text can be "leave" or "move/head/go somewhere"
            if(text.Length != 2 && text.Length != 1)
            {
                return "I don't know how to move like that";
            }
            
            if(text[0] != "leave" && text.Length == 1)
            {
                return "Where do you want to go?";
            }

            if(text[0] == "leave")
            {
                p.Leave(); //goes back to the previous location
                string message;
                message = "You have headed back to the " + p.Location.Name;
                return message;
            }
            else //if text[0] = move, go or head - then move the player in the direction indicated
            {
                Location _location = p.Location; //getting the players location
                Path _path = _location.GetPath(text[1]); //getting the path of the location

                if(_path == null)
                {
                    return "This location has no path in the " + text[1] + " direction";
                }

                //if the location has paths:
                _location = _path.SetDestination(); //getting the locations of the path

                if (_location == null) //if the requested dirction does not exist
                {
                    return "Location not found";
                }

                p.Location = _location;

                //if the path is found, return the new location
                return _path.FullDescription;

            }
        }
    }
}
