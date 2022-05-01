using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockApp;


namespace NUnitTestClock
{
    public class TestClock
    {
        private Clock _testableClock;
        [SetUp]
        public void Setup()
        {
            _testableClock = new Clock();
        }

        [Test]
        public void InitialiseTest()
        {
            Assert.AreEqual("00:00:00", _testableClock.Time, "Initialise Test");
        }

        [Test]
        public void SecondsTest()
        {
            for (int i = 0; i < 59; i++)
            {
                _testableClock.Tick();
            }
            Assert.AreEqual("00:00:59", _testableClock.Time, "Testing seconds = 59");

            _testableClock.Tick();
            Assert.AreEqual("00:01:00", _testableClock.Time, "Testing seconds don't go over 59");
        }

        [Test]
        public void MinutesTest()
        {
            for (int i = 0; i < 3599; i++)
            {
                _testableClock.Tick();
            }
            Assert.AreEqual("00:59:59", _testableClock.Time, "Testing minutes = 59");

            _testableClock.Tick();
            Assert.AreEqual("01:00:00", _testableClock.Time, "Testing minutes don't go over 59");
        }

        [Test]
        public void HoursTest()
        {
            for (int i = 0; i < 86399; i++)
            {
                _testableClock.Tick();
            }
            Assert.AreEqual("23:59:59", _testableClock.Time, "Testing hours = 23");

            _testableClock.Tick();
            Assert.AreEqual("00:00:00", _testableClock.Time, "Testing hours don't go over 23");
        }
        
        [Test]
        public void OutOf24Test()
        {
            for (int i = 0; i < 86401; i++)
            {
                _testableClock.Tick();
            }
            Assert.AreEqual("00:00:01", _testableClock.Time, "Out of 24 hours Test");
        }

        [Test]
        public void ResetTest()
        {
            for (int i = 0; i < 70142; i++)
            {
                _testableClock.Tick();
            }
            Assert.AreEqual("19:29:02", _testableClock.Time, "Testing Time is not 0");

            _testableClock.Reset();
            Assert.AreEqual("00:00:00", _testableClock.Time, "Reset Test");
        }
    }
}