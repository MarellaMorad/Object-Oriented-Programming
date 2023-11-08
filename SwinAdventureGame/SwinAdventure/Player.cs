using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Location _location; //to allow player to be in a location
        private Inventory _inventory; //to manage the Player's items
        private Location _lastLocation; //to allow player to leave a location (go back to the previous one)

        //default constructor
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit Hallway");
        } 

        public GameObject Locate(string id)
        {
            //three checks
            if (AreYou(id)) //if the player is what is to be located
            {
                return this; //retunring the player as a game object around the player
            }
            else if (_inventory.HasItem(id)) //if the player had what is being located
            {
                return _inventory.Fetch(id); //if the game object is not the player, then fetch it from inventory
            }
            else //if the item can be located where the player is
            {
                return _location.Locate(id);
            }
        }

        public override string FullDescription //overridden with the extra infromation
        {
            get
            {
                //returns the full description
                String fullDesc = "You are " + Name + " " + base.FullDescription +  "\nYou are carrying:\n" + _inventory.ItemList;

                return fullDesc;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                //setting the last location to the current location then changing to the new location
                if(_location != null)
                {
                    _lastLocation = _location;
                }
                else
                {
                    _lastLocation = value;
                }

                _location = value;
            }
        }

        public void Leave()
        {
            _location = _lastLocation; //returning to the last location
        }
    }
}
