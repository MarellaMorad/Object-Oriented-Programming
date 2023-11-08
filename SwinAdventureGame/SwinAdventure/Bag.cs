using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        //default constructor
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this; //retunring the bag as a game object around the player
            }
            else
            {
                return _inventory.Fetch(id); //fetch the bag it from inventory
            }
        }

        public override string FullDescription
        {
            get
            {
                string fullDesc = base.FullDescription + "\nYou look in the " + Name + " and you see:\n" + _inventory.ItemList;
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
    }
}
