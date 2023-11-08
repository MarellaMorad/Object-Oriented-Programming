using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class BagUnitTests
    {
        Bag b1, b2;

        Item shovel;
        Item sword;
        Item pc;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");

            b1 = new Bag(new string[] {"bag"}, "plastic bag", "This is a clear plastic bag");
            b2 = new Bag(new string[] { "wallet" }, "wallet", "This is a black wallet");

            b1.Inventory.Put(shovel);
            b2.Inventory.Put(pc);
            b1.Inventory.Put(b2);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Assert.AreEqual(b1.Locate("shovel"), shovel, "Bag cannot locate shovel");
        }

        [Test]
        public void TestBagLocatesIteslef()
        {
            Assert.AreEqual(b1.Locate("bag"), b1, "Bag cannot locate itself1");
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.IsNull(b1.Locate("pc"), "Bag can locate pc");
        }

        [Test]
        public void TestBagFullDescription()
        {
            string expected =
             "This is a clear plastic bag\n"+
            "You look in the " + b1.Name + " and you see:\n" +
            "     a shovel (shovel)\n" +
            "     a wallet (wallet)\n";
            Assert.AreEqual(expected, b1.FullDescription, "Full description incorrectly formatted");
        }

        [Test]
        public void TestBagInBag()
        {
            Assert.AreEqual(b1.Locate("wallet"), b2, "Bag 2 is not in Bag 1"); //b1 can locate b2
            Assert.AreEqual(b1.Locate("shovel"), shovel, "shovel cannot be located in bag 1"); //b1 can locate other items in b1
            Assert.IsNull(b2.Locate("bag"), "Bag 1 is in Bag 2"); //b2 cannot locate b1
            Assert.IsNull(b1.Locate("pc"), "Bag 1 can locate pc"); //b1 cannot locate items from b2
        }
    }
}
