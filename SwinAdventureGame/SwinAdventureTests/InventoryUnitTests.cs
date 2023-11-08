using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class InventoryUnitTests
    {
        Item shovel;
        Item sword;
        Item pc;

        Inventory inventory;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sword = new Item(new string[] { "sword" }, "bronze sword", "This is a shiny sword");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");

            inventory = new Inventory();
            inventory.Put(shovel);
            inventory.Put(sword);
            inventory.Put(pc);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(inventory.HasItem("shovel"), "Inventory is empty"); //checking if pc is found in inventory
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(inventory.HasItem("crown"), "Inventory does not have crown"); //testing if inventory has sword (should return false)
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.AreEqual(inventory.Fetch("pc"), pc, "Inventory does not have pc");
            Assert.IsTrue(inventory.HasItem("pc"), "Inventory is empty"); //item has not been removed - only fetched
        }

        [Test]
        public void TestTakeItem()
        {
            inventory.Take("pc");
            Assert.IsFalse(inventory.HasItem("pc"), "Item not removed");
        }

        [Test]
        public void TestItemList()
        {
            string expected =
                "     a shovel (shovel)\n" +
                "     a bronze sword (sword)\n" +
                "     a small computer (pc)\n";
            Assert.AreEqual(inventory.ItemList, expected, "List incorrectly formatted");
        }
    }
}
