using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;

        public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
        }

        public Location SetDestination()
        {
            //returns the destentation which will be set to the player's location in the move command
            return _destination;
        }

        public override string FullDescription
        {
            get
            {
                return "You head " + this.Name + 
                       "\nYou travel through a " + base.FullDescription + 
                       "\nYou have arrived in the " + _destination.Name;
            }
        }
    }
}
