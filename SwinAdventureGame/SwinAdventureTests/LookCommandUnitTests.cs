using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class LookCommandUnitTests
    {
        Item shovel;
        Item sword;
        Item gem;

        Player player;

        Bag b1;
        Bag b2;

        LookCommand look;

        Location hall;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            gem = new Item(new string[] { "gem" }, "red gem", "This is a shiny red gem");

            b1 = new Bag(new string[] { "bag" }, "plastic bag", "This is a clear plastic bag");
            b2 = new Bag(new string[] { "wallet" }, "wallet", "This is a black wallet");

            hall = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit Hallway");

            player = new Player("Marella", "The amazing player");

            player.Location = hall;

            look = new LookCommand();

            b2.Inventory.Put(shovel);
            b1.Inventory.Put(b2);

            player.Inventory.Put(shovel);
            player.Inventory.Put(b1);
            player.Inventory.Put(gem);

            look = new LookCommand();

            
        }

        [Test]
        public void TestLookAtMe()
        {
            string expected =
            "You are Marella The amazing player\n" +
            "You are carrying:\n" +
            "     a shovel (shovel)\n" +
            "     a plastic bag (bag)\n" +
            "     a red gem (gem)\n";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "inventory"}), "TestLookAtMe failed");
        }

        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);
            string expected = "This is a shiny red gem";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem"}), "TestLookAtGem Failed");
        }

        [Test]
        public void TestLookAtUnk()
        {
            player.Inventory.Take("gem");
            string expected = "I cannot find the gem";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem" }), "TestLookAtUnk Failed");
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            
            string expected = "This is a shiny red gem";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory"}), "TestLookAtGemInMe Failed");
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            b1.Inventory.Put(gem);
            string expected = "This is a shiny red gem";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), "TestLookAtGemInMe Failed");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            player.Inventory.Take("bag");
            string expected = "I cannot find the bag";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), "TestLookAtGemInMe Failed");
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            string expected = "I cannot find the gem in the plastic bag";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), "TestLookAtGemInMe Failed");
        }

        [Test]
        public void TestInvalidLook()
        {
            string expected = "I don't know how to look like that";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "in"}), "Test text length = 4 not accepted Failed");

            expected = "What do you want to look at?";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "int", "gem"}), "Test look at Failed");

            expected = "What do you want to look in?";
            Assert.AreEqual(expected, look.Execute(player, new string[] { "look", "at", "gem", "on", "bag" }), "Test look at in Failed");
        }
    }
}
