using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class LocationUnitTests
    {
        Item shovel;
        Item sword;
        Item gem;

        Player player;

        Bag b1;
        Bag b2;

        LookCommand look;
        
        Location location;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");

            b1 = new Bag(new string[] { "bag" }, "plastic bag", "This is a clear plastic bag");
            b2 = new Bag(new string[] { "wallet" }, "wallet", "This is a black wallet");

            player = new Player("Marella", "The amazing player");

            look = new LookCommand();

            b2.Inventory.Put(shovel);
            b1.Inventory.Put(b2);

            player.Inventory.Put(shovel);
            player.Inventory.Put(b1);
            player.Inventory.Put(gem);

            location = new Location(new string[] { "closet" }, "small Closet", "A small dark closet, with an odd smell");
        }

        [Test]
        public void TestIdentifiableLocation()
        {
            Assert.IsTrue(location.AreYou("closet"), "Location is not identifiable"); //location is identifiable by AreYou()
        }

        [Test]
        public void TestLocateItems()
        {
            location.Inventory.Put(gem);
            Assert.AreEqual(location.Locate("gem"), gem, "Gem cannot be found in the location");
        }

        [Test]
        public void TestLocationFullDescription()
        {
            location.Inventory.Put(gem);
            string expected =
            "You are in the small Closet\n" +
            "A small dark closet, with an odd smell\n" +
            "There are exits to the \n" +
            "In this room you can see:\n" +
            "     a red gem (gem)\n";
            Assert.AreEqual(location.FullDescription, expected);
        }
    }
}
