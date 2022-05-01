using System;
using System.Collections.Generic;
using System.Text;

namespace ClockApp
{
    public class Clock
    {
        private Counter _hours;
        private Counter _minutes;
        private Counter _seconds;

        public Clock()
        {
            //creating new Counter objects for hours, minutes and seconds
            _hours = new Counter("hours");
            _minutes = new Counter("minutes");
            _seconds = new Counter("seconds");
        }

        public void Tick()
        {
            //resetting seconds when reaching 59, otherwise keep incrementing
            if(_seconds.Ticks > 59)
            {
                _seconds.Reset();
                //resetting minutes when reaching 59, otherwise keep incrementing
                if (_minutes.Ticks > 59)
                {
                    _minutes.Reset();
                    //resetting hours when reaching 23, otherwise keep incrementing
                    if (_hours.Ticks > 23)
                    {
                        _hours.Reset();
                    }
                    else
                    {
                        _hours.Increment();
                    }
                }
                else
                {
                    _minutes.Increment();
                }
            }
            else
            {
                _seconds.Increment();
            }

        }

        public void Reset()
        {
            //resetting all the Counter objects back to 00
            _hours.Reset();
            _minutes.Reset();
            _seconds.Reset();
        }

        public string Time
        {
            get
            {
                // returning time in the required format hh:mm:ss
                return $"{_hours.Ticks:00}:{_minutes.Ticks:00}:{_seconds.Ticks:00}";
                // using the $ sign, makes it easier to format the time, all in one line
            }
        }
    }
}
