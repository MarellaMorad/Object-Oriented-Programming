using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class PlayerUnitTests
    {
        Player player;
        Item shovel;
        Item sword;
        Item pc;
        Item gem;

        Location location;

        [SetUp]
        public void Setup()
        {
            location = new Location(new string[] { "closet" }, "small Closet", "A small dark closet, with an odd smell");
            player = new Player("Marella", "the amazing player");
            player.Location = location;
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");

            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.Inventory.Put(pc);
        }

        [Test]
        public void TestIdentifiablePlayer()
        {
            Assert.IsTrue(player.AreYou("me"), "defauls player not identifiable1");
            Assert.IsTrue(player.AreYou("inventory"), "defauls player not identifiable2");
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.AreEqual(player.Locate("pc"), pc, "Player cannot locate pc");
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(player.Locate("me"), player, "Player cannot locate itself1");
            Assert.AreEqual(player.Locate("inventory"), player, "Player cannot locate itself2");
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(player.Locate("apple"), "Player can locate apple");
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string expected =
            "You are Marella the amazing player\n" +
            "You are carrying:\n" +
            "     a shovel (shovel)\n" +
            "     a bronze sword (sword)\n" +
            "     a small computer (pc)\n";
            Assert.AreEqual(player.FullDescription, expected, "Full description incorrectly formatted");
        }

        //Add a test for Players to locate items in their location
        [Test]
        public void TestPlayerLocateItemInItsLocation()
        {
            location.Inventory.Put(gem);
            Assert.AreEqual(player.Locate("gem"), gem);
        }
    }
}
