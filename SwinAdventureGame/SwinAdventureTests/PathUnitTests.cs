using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class PathUnitTests
    {
        Player player;
        Location hall, garden, lab;
        Path pathHtoL, pathHtoG, pathGtoH, pathGtoL, pathLtoH, pathLtoG;
        MoveCommand move;

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

            move = new MoveCommand();
        }

        [Test]
        public void TestMovePlayer()
        {
            string expected = "You head South\nYou travel through a slide\nYou have arrived in the Laboratory";
            Assert.AreEqual(expected, move.Execute(player, new string[] { "move", "south" }), "Player cannot be moved south");
        }

        [Test]
        public void TestGetPath()
        {
            Assert.AreEqual(pathGtoL, garden.GetPath("sw"));
        }

        [Test]
        public void TestLeaveLocation()
        {

            move.Execute(player, new string[] { "move", "south" }); //player is now in the lab
            Assert.AreEqual("You have headed back to the Hallway", move.Execute(player, new string[] { "leave" }));
        }

        [Test]
        public void TestInvalidMove()
        {
            //invalid direction
            Assert.AreEqual("This location has no path in the somewhere direction", move.Execute(player, new string[] { "move", "somewhere" }));
            Assert.AreEqual(hall, player.Location, "Player left somewhere...");

            //moving the player to different location and test again
            move.Execute(player, new string[] { "go", "east" }); //go to garden
            move.Execute(player, new string[] { "head", "south west" }); //go to lab

            //wrong length of the move command
            //One word command in only accepted for leave, not for move, go and head
            Assert.AreEqual("This location has no path in the south direction", move.Execute(player, new string[] { "move", "south" })); //cannot move south from the lab
            Assert.AreEqual("Where do you want to go?", move.Execute(player, new string[] { "move" }));
        }
    }
}
