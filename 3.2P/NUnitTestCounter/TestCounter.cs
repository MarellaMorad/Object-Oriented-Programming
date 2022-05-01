using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockApp;

namespace NUnitTestCounter
{
    public class TestCounter
    {
        private Counter _testableCounter;
        [SetUp]
        public void Setup()
        {
            _testableCounter = new Counter("Counter 1");
        }

        [Test]
        public void Initialise()
        {
            Assert.AreEqual(0, _testableCounter.Ticks, "Initialise Test");
        }

        [Test]
        public void OneIncrement()
        {
            _testableCounter.Increment();
            Assert.AreEqual(1, _testableCounter.Ticks, "One Increment Test");
        }

        [Test]
        public void Increments()
        {
            for (int i = 0; i < 5; i++)
            {
                _testableCounter.Increment();
            }
            Assert.AreEqual(5, _testableCounter.Ticks, "Multiple Increments Test");
        }

        [Test]
        public void Reset()
        {
            _testableCounter.Reset();
            Assert.AreEqual(0, _testableCounter.Ticks, "Reset Test");
        }
    }
}