using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        //short textual description of the game object
        public string Name
        {
            get
            {
                return _name;
            }
        }

        //referring to the object
        public string ShortDescription
        {
            get
            {
                //return name + firstId of the game object in the format:
                // a small computer (pc) - where small computer is the _name of the game object and pc is the first id of the game object
                string shortDesc = "A " + _name + " (" + FirstId + ")";
                return shortDesc;
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return _description; //by default, returns description
                //will be overridden by child classes
            }
        }
    }
}
