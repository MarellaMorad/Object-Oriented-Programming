using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class TakeCommandTests
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

            b2.Inventory.Put(gem);
            lab.Inventory.Put(b2);

            command = new CommandProcessor();
        }

        [Test]
        public void TestTakeCommand()
        {
            //list the inventory of the location
            string expected =
            "You are in the Hallway\n" +
            "This is a long well lit Hallway\n" +
            "There are exits to the east and south\n" +
            "In this room you can see:\n" +
            "     a bronze sword (sword)\n" +
            "     a plastic bag (bag)\n";
            Assert.AreEqual(player.Location.FullDescription, expected);

            //Add to the player's inventory
            Assert.AreEqual("You have taken the bronze sword from the Hallway", command.Execute(player, new string[] { "pickup", "sword" }), "Take command failed");
            Assert.AreEqual(sword, player.Locate("sword"), "Sword was not added properly");
        }

        [Test]
        public void TestInvalidTake()
        {
            //taking items that are not in the location
            Assert.AreEqual("shovel was not found in the Hallway", command.Execute(player, new string[] { "take", "shovel" }), "Take command failed");
            Assert.AreEqual(null, player.Locate("shovel"), "Shovel was added somehow");

            //incorrect length of take command
            Assert.AreEqual("I don't know how to transfer like that", command.Execute(player, new string[] { "take", "shovel", "from" }));

            //taking items that are not in the bag in the location
            Assert.AreEqual("shovel was not found in the plastic bag", command.Execute(player, new string[] { "take", "shovel", "from", "bag" }));

            //taking items from a bag that's not in the location
            Assert.AreEqual("wallet was not found", command.Execute(player, new string[] { "take", "shovel", "from", "wallet" }));
        }

        [Test]
        public void TestTakeFromCommand()
        {
            string expected =
            "This is a clear plastic bag\n" +
            "You look in the plastic bag and you see:\n" +
            "     a small computer (pc)\n";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "look", "at", "bag" }));
            Assert.AreEqual("This is a computer from the future", command.Execute(player, new string[] { "look", "at", "pc", "in", "bag" }));

            //Add to the player's inventory
            Assert.AreEqual("You have taken the small computer from the plastic bag", command.Execute(player, new string[] { "take", "pc", "from", "bag" }), "Take from command failed");
            Assert.AreEqual(pc, player.Locate("pc"), "pc was not added properly");
        }
    }
}
