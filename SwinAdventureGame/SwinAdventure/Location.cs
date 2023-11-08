using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory; //to conatin items
        private List<Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public GameObject Locate(string id)
        {
            return _inventory.Fetch(id); //to locate items in the location inventory
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path); //adding the paths to the location
        }

        public Path GetPath(string id)
        {
            foreach(Path p in _paths)
            {
                if(p.AreYou(id))
                {
                    return p;
                }
            }

            return null;
        }

        public override string FullDescription
        {
            get
            {
                //adding the paths of a location
                string paths = "";
                int count = 0;
                foreach (Path p in _paths)
                {
                    if(count == 0)
                    {
                        paths = p.Name.ToLower();
                    }
                    else
                    {
                        paths = paths + " and " + p.Name.ToLower();
                    }
                    count++; 
                }

                string fullDesc = "You are in the " + Name + "\n" + base.FullDescription
                                + "\nThere are exits to the " + paths //addition of exits available
                                + "\nIn this room you can see:\n" + _inventory.ItemList;

                return fullDesc;
            }
        }
    }
}
