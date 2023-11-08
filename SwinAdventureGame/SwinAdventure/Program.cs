using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the objects of the game:
            Player player;
            Location hall, garden, lab;
            Path pathHtoL, pathHtoG, pathGtoH, pathGtoL, pathLtoH, pathLtoG;
            CommandProcessor command;
            Item shovel, sword, gem, pc, rope, scope, goggles, coat;
            Bag bag, cart, handbag;

            //Add locations
            hall = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit Hallway");

            garden = new Location(new string[] { "garden" }, "Garden", "This is a big garden with a lot of secret spots");

            lab = new Location(new string[] { "lab" }, "Laboratory", "This is where the magic is created");
            
            //Setup the paths
            pathHtoL = new Path(new string[] { "south", "s", "down" }, "South", "slide", lab);
            pathHtoG = new Path(new string[] { "east", "e", "right" }, "East", "small door", garden);

            pathGtoH = new Path(new string[] { "west", "w", "left" }, "West", "small door", hall);
            pathGtoL = new Path(new string[] { "sw", "south_west" }, "South West", "roller coaster", lab);

            pathLtoH = new Path(new string[] { "n", "north", "up" }, "North", "ladder", hall);
            pathLtoG = new Path(new string[] { "ne", "north_east" }, "North East", "roller coaster", garden);

            //Add the paths to each location
            hall.AddPath(pathHtoG);
            hall.AddPath(pathHtoL);

            garden.AddPath(pathGtoL);
            garden.AddPath(pathGtoH);

            lab.AddPath(pathLtoG);
            lab.AddPath(pathLtoH);

            //Create the items
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");
            rope = new Item(new string[] { "rope" }, "rope", "This is the strongest rope ever");
            scope = new Item(new string[] { "scope" }, "hand scope", "This is a golden scope with x1000 magnification");
            goggles = new Item(new string[] { "goggles" }, "IR goggles", "These are the best night vision goggles");
            coat = new Item(new string[] { "coat" }, "lab coat", "This is a white lab coat");

            //Create the bags
            bag = new Bag(new string[] { "bag" }, "plastic bag", "This is a clear plastic bag");
            cart = new Bag(new string[] { "cart" }, "gardening cart", "This is a big gardening cart that fits large items");
            handbag = new Bag(new string[] { "handbag" }, "handbag", "This is a leather handbag");

            //Setup the game by adding items to locations and bags
            hall.Inventory.Put(sword);
            handbag.Inventory.Put(gem);
            hall.Inventory.Put(handbag);

            garden.Inventory.Put(scope);
            garden.Inventory.Put(rope);
            cart.Inventory.Put(shovel);
            garden.Inventory.Put(cart);

            lab.Inventory.Put(coat);
            lab.Inventory.Put(pc);
            bag.Inventory.Put(goggles);
            lab.Inventory.Put(bag);

            command = new CommandProcessor();

            Console.WriteLine("Please enter your player's name: ");
            string playerName = Console.ReadLine();
            //getting the player's description from Console (user)
            Console.WriteLine("Please enter your player's description: ");
            string playerDesc = Console.ReadLine();
            //creating the player using info from the user:
            player = new Player(playerName, playerDesc);

            player.Location = hall; //default location of the player

            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Swin-Adventure, {0}!", playerName);
            Console.WriteLine("You have arrived in the " + player.Location.Name);

            bool done = false; //to keep looping until the player chooses to stop
            while(!done)
            {
                Console.Write("Command -> ");
                string userCommand = Console.ReadLine(); //getting the command from the user
                string[] commandArr = new[] { userCommand }; //converting into string[] array
                commandArr = userCommand.Split(" "); //splitting the command based on spaces between words
                Console.WriteLine(" ");
                string reply = command.Execute(player, commandArr);
                Console.WriteLine(reply); //executing command using command processor
                //Console.WriteLine(" ");

                //checking if the player wants to enter another command

                if(reply.ToLower() == "good bye") //running for 10 times before asking the user if they want to stop
                { 
                    done = true;
                }
            }
        }
    }
}
