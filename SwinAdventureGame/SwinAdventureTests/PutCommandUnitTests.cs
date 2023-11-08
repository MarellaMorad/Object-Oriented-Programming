using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class PutCommandUnitTests
    {
        Player player;
        Location hall, garden, lab;
        Path pathHtoL, pathHtoG, pathGtoH, pathGtoL, pathLtoH, pathLtoG;
        CommandProcessor command;
        Item shovel, sword, gem, pc;
        Bag b1, b2;

        [SetUp]
        public void Setup()
        {
            player = new Player("Marella", "The amazing player");
            hall = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit Hallway");
            garden = new Location(new string[] { "garden" }, "Garden", "This is a big garden with a lot of secret spots");
            lab = new Location(new string[] { "lab" }, "Laboratory", "This is where the magic is created");

            pathHtoL = new Path(new string[] { "south", "s", "down" }, "South", "slide", lab);
            pathHtoG = new Path(new string[] { "east", "e" }, "East", "small door", garden);

            pathGtoH = new Path(new string[] { "west", "w" }, "West", "small door", hall);
            pathGtoL = new Path(new string[] { "sw", "south west" }, "South West", "roller coaster", lab);

            pathLtoH = new Path(new string[] { "n", "north", "up" }, "North", "ladder", hall);
            pathLtoG = new Path(new string[] { "ne", "north west" }, "North West", "roller coaster", garden);

            //setting the map
            /*
             * Hall -----> Garden
             * |
             * |
             * Lab
             */

            //Add the paths to each location
            hall.AddPath(pathHtoG);
            hall.AddPath(pathHtoL);

            garden.AddPath(pathGtoL);
            garden.AddPath(pathGtoH);

            lab.AddPath(pathLtoG);
            lab.AddPath(pathLtoH);

            player.Location = hall; //default location of the player

            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");

            b1 = new Bag(new string[] { "bag" }, "plastic bag", "This is a clear plastic bag");
            b2 = new Bag(new string[] { "wallet" }, "wallet", "This is a black wallet");

            hall.Inventory.Put(sword);
            b1.Inventory.Put(pc);
            hall.Inventory.Put(b1);

            garden.Inventory.Put(shovel);
            garden.Inventory.Put(gem);

            b2.Inventory.Put(pc);
            lab.Inventory.Put(b2);

            command = new CommandProcessor();
        }

        [Test]
        public void TestPutCommand()
        {
            /*
            //list the inventory of the location
            string expected =
            "You are in the Hallway\n" +
            "This is a long well lit Hallway\n" +
            "There are exits to the east and south\n" +
            "In this room you can see:\n" +
            "     a bronze sword (sword)\n" +
            "     a plastic bag (bag)\n";
            Assert.AreEqual(player.Location.FullDescription, expected);

            //Add plastic bag to the player's inventory
            Assert.AreEqual("You have taken the plastic bag from the Hallway", command.Execute(player, new string[] { "pickup", "bag" }), "Take command failed");
            Assert.AreEqual(b1, player.Locate("bag"), "Bag was not added properly");
            */

            //Put sword in bag
            player.Inventory.Put(sword);
            Assert.AreEqual("You have put the bronze sword in the plastic bag", command.Execute(player, new string[] { "put", "sword", "in", "bag" }), "Put command failed");
            Assert.IsFalse(player.Inventory.HasItem("sword"));
        }

        [Test]
        public void TestDropCommand()
        {
            player.Inventory.Put(gem);
            Assert.AreEqual("You have dropped the red gem in the Hallway", command.Execute(player, new string[] { "drop", "gem" }), "Drop command failed");
            Assert.IsTrue(player.Location.Inventory.HasItem("gem"));
        }

        [Test]
        public void TestInvalidDrop()
        {
            player.Inventory.Put(shovel);
            Assert.AreEqual("gem was not found in your inventory", command.Execute(player, new string[] { "drop", "gem" }), "Drop command aceepts invalid input");
            Assert.IsTrue(player.Inventory.HasItem("shovel"));
            Assert.IsFalse(player.Location.Inventory.HasItem("gem"));
        }

        [Test]
        public void TestInvalidPut()
        {
            //moving the player to different location and test again
            command.Execute(player, new string[] { "go", "east" }); //go to garden
            command.Execute(player, new string[] { "head", "south west" }); //go to lab

            lab.Inventory.Put(gem);

            //Put gem on bag
            Assert.AreEqual("Where do you want to put the gem?", command.Execute(player, new string[] { "put", "gem", "on", "wallet" }), "Put command accepts invalid input");
            Assert.IsFalse(b2.Inventory.HasItem("gem"));

            //gem not in location
            lab.Inventory.Take("gem");
            string expected = "You are in the Laboratory\nThis is where the magic is created\n"
                                + "There are exits to the north west and north"
                                + "\nIn this room you can see:\n" +
                                "     a wallet (wallet)\n";
            Assert.AreEqual(expected, lab.FullDescription);
            Assert.AreEqual("gem was not found in your inventory", command.Execute(player, new string[] { "put", "gem", "in", "wallet" }), "Put command accepts invalid input");
        }
    }
}
