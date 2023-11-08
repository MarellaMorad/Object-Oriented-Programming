using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    _items.Remove(i);
                    return i;
                }
            }

            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                //locating the item using AreYou and returning it
                if (i.AreYou(id))
                {
                    return i;
                }
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                StringBuilder itemList = new StringBuilder();

                foreach (Item i in _items)
                {
                    //speces are used instead of \t as \t does not work with winForms when using the GUI
                    itemList.Append("     " + i.ShortDescription.ToLower() + "\n");
                }

                return itemList.ToString();
            }
        }
    }
}
