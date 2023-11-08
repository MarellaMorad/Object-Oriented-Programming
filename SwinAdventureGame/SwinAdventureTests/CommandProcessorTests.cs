using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class CommandProcessorTests
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
        public void TestLookCommand()
        {
            player.Inventory.Put(gem);
            string expected = "This is a shiny red gem";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "look", "at", "gem" }), "Test look command failed");
        }

        [Test]
        public void TestMoveCommand()
        {
            string expected = "You head South\nYou travel through a slide\nYou have arrived in the Laboratory";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "move", "south" }), "Player cannot be moved south");
        }

        [Test]
        public void TestInvalidCommand()
        {
            Assert.AreEqual(command.Execute(player, new string[] { "dive", "left" }), "I don't understand dive left");
        }

        [Test]
        public void TestInvalidMoveCommands()
        {
            //invalid direction
            Assert.AreEqual("This location has no path in the somewhere direction", command.Execute(player, new string[] { "move", "somewhere" }));
            Assert.AreEqual(hall, player.Location, "Player left somewhere...");

            //moving the player to different location and test again
            command.Execute(player, new string[] { "go", "east" }); //go to garden
            command.Execute(player, new string[] { "head", "south west" }); //go to lab

            //wrong length of the move command
            //One word command in only accepted for leave, not for move, go and head
            Assert.AreEqual("This location has no path in the south direction", command.Execute(player, new string[] { "move", "south" })); //cannot move south from the lab
            Assert.AreEqual("Where do you want to go?", command.Execute(player, new string[] { "move" }));
        }

        [Test]
        public void TestInvalidLookCommands()
        {
            string expected = "I don't know how to look like that";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "look", "at", "gem", "in" }), "Test text length = 4 not accepted Failed");

            expected = "I don't understand like at gem";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "like", "at", "gem" }), "Test look word not found Failed");

            expected = "What do you want to look at?";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "look", "int", "gem" }), "Test look at Failed");

            expected = "What do you want to look in?";
            Assert.AreEqual(expected, command.Execute(player, new string[] { "look", "at", "gem", "on", "bag" }), "Test look at in Failed");
        }
    }
}
