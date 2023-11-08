using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id); //locate an item using its id (inside the container)

        public string Name //returnig the name of containter
        {
            get;
        }

        public Inventory Inventory
        {
            get;
        }
    }
}
