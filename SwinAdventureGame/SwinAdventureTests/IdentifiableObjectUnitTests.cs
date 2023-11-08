using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    public class IdentifiableObjectUnitTests
    {
        private IdentifiableObject _testableObject;

        [SetUp]
        public void Setup()
        {
            _testableObject = new IdentifiableObject(new string[] { "fred", "bob" });

        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testableObject.AreYou("fred"), "testing fred");
            Assert.IsTrue(_testableObject.AreYou("bob"), "testing bob");
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testableObject.AreYou("wilma"));
            Assert.IsFalse(_testableObject.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testableObject.AreYou("FRED"));
            Assert.IsTrue(_testableObject.AreYou("bOB"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual("fred", _testableObject.FirstId);
        }

        [Test]
        public void TestAddId()
        {
            Assert.IsFalse(_testableObject.AreYou("wilma"));
            _testableObject.AddIdentifier("wilma");
            Assert.IsTrue(_testableObject.AreYou("wilma"));
        }
    }
}