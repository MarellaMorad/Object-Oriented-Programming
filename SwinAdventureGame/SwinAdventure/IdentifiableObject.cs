using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        public bool AreYou(string id)
        {
            foreach (string i in _identifiers)
            {
                if (_identifiers.Contains(id.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        //read only, no set property
        public string FirstId
        {
            get
            {
                //returns the first identifier from _identifiers (or an empty string)
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return " ";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            //converts the identifier to lower case and stores it in _identifiers
            _identifiers.Add(id.ToLower());
        }
    }
}
