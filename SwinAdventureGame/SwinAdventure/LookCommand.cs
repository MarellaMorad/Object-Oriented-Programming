using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look", "examine", "inventory" })
        {

        }

        //FIX to work with the location

        public override string Execute(Player p, string[] text)
        {
            if(text.Length !=1 && text.Length != 2 && text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if(text.Length == 1 && text[0] == "look") //if the player types look
            {
                return p.Location.FullDescription; //prints the location's full description
            }

            bool player = false;

            if (text.Length == 1 && text[0] == "inventory") //if the player types inventory, it is same as look at inventory
            {
                player = true;
                return LookAtIn(text[0], p, player);
            }

            //text.Length = 2
            if (text.Length == 2 && text[0] == "examine")
            {
                player = true;
                return LookAtIn(text[1], p, player);
            }

            //text.Length = 3
            if (text.Length == 3)
            {
                if(text[1].ToLower() == "in")
                {
                    player = false;
                    return LookAtIn(text[2], p, player);
                }

                if (text[1].ToLower() != "at")
                {
                    return "What do you want to look at?";
                }

                player = true;
                return LookAtIn(text[2], p, player);
            }
            else //if text.Length == 5
            {
                player = false;
                if(text[3] != "in")
                {
                    return "What do you want to look in?";
                }

                IHaveInventory _container = FetchContainer(p, text[4]);
                if(_container != null)
                {
                    return LookAtIn(text[2], _container, player);
                }
                else
                {
                    return "I cannot find the " + text[4];
                }
            }
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container, bool player)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription; 
            }
            else
            {
                if(player == true)
                {
                    return "I cannot find the " + thingId;
                }
                else
                {
                    return "I cannot find the " + thingId + " in the " + container.Name;

                }
                
            }
        }
    }
}
