using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class ItemUnitTests
    {
        Item shovel;
        Item sowrd;
        Item pc;

        [SetUp]
        public void Setup()
        {
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a might fine shovel");
            sowrd = new Item(new string[] { "sowrd" }, "bronze sowrd", "This is a shiny sowrd");
            pc = new Item(new string[] { "pc" }, "small computer", "This is a computer from the future");
        }

        [Test]
        public void TestIdentifiableItem()
        {
            Assert.IsTrue(shovel.AreYou("shovel"), "Item does not match id");
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("A shovel (shovel)", shovel.ShortDescription, "Short Description does not match");
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(shovel.FullDescription, "This is a might fine shovel", "Full Description does not match");
        }
    }
}
