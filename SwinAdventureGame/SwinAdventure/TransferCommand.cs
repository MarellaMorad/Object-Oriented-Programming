using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class TransferCommand : Command
    {
        public TransferCommand() : base(new string[] {"take", "pickup", "put", "drop"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            //accepted inputs are:
            //take item, take item from bag, pickup item
            // put item in bag, drop item
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to transfer like that";
            }

            //if text.Length == 2 or 4, the code continues
            Item _item; //holds the item to be transfered
            if (text.Length == 2) 
            {
                if(text[0].ToLower() == "take" || text[0].ToLower() == "pickup") // take / pickup item
                {
                    _item = Transfer(p.Location, p, text[1]);
                    if (_item != null)
                        return "You have taken the " + _item.Name + " from the " + p.Location.Name;
                    return text[1] + " was not found in the " + p.Location.Name; //if _item is null
                }
                

                if(text[0].ToLower() == "drop" || text[0].ToLower() == "put") // put / drop item
                {
                    _item = Transfer(p, p.Location, text[1]);
                    if (_item != null)
                        return "You have dropped the " + _item.Name + " in the " + p.Location.Name;
                    return text[1] + " was not found in your inventory"; //if _item is null
                }

                
            }
            
            //if text.Length == 4
            IHaveInventory container;
            if (p.Locate(text[3]) != null)
            {
                container = FetchContainer(p, text[3]) as IHaveInventory;
                if ((text[0].ToLower() == "take" || text[0].ToLower() == "pickup")) //take/pickup item from container
                {
                    if (text[2].ToLower() != "from")
                        return "Where do you want to take the " + text[1] + " from?";
                    _item = Transfer(container, p, text[1]);
                    if (_item != null)
                        return "You have taken the " + _item.Name + " from the " + container.Name;
                    return text[1] + " was not found in the " + container.Name; //if _item is null
                }
                else if ((text[0].ToLower() == "put" || text[0].ToLower() == "drop")) //put/drop item in container
                {
                    if (text[2].ToLower() != "in")
                        return "Where do you want to put the " + text[1] + "?";
                    _item = Transfer(p, container, text[1]);
                    if (_item != null)
                        return "You have put the " + _item.Name + " in the " + container.Name;
                    return text[1] + " was not found in your inventory"; //if _item is null
                }

                
            }
            return text[3] + " was not found";
        }

        public Item Transfer(IHaveInventory source, IHaveInventory destination, string itemID)
        {
            if (source.Inventory.HasItem(itemID))
            {
                Item item = source.Inventory.Take(itemID); ;
                destination.Inventory.Put(item);
                return item;
            }

            return null;
        }

        public GameObject FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId);
        }
    }
}
