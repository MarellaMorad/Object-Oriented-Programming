using System;
using System.Collections.Generic;
using System.Text;

namespace CounterTest
{
    public class Counter
    {
        private int _count;
        private string _name;

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        //Name property
        public string Name
        {
            //get is read only
            //get and set are both read and write
            get  //should always return a value
            {
                return _name;
            }
            set //should always change a value
            {
                _name = value;
            }
        }

        //read only property
        public int Ticks
        {
            get
            {
                return _count;
            }
        }

        public void Increment()
        {
            _count = _count + 1;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
