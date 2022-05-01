using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    public abstract class LibraryResource
    {
        //common fields in Game and Book are name and onloan
        private string _name;
        private bool _onLoan;

        public LibraryResource(string name, string creator)
        {
            _name = name;
            _onLoan = false;
        }

        //Name readonly property
        public string Name
        {
            get
            {
                return _name;
            }
        }

        //Creator abstract readonly property - to be overridden by children classes (Game & Book)
        public abstract string Creator
        {
            get;
        }

        //OnLoan property - can read and write
        public bool OnLoan
        {
            get
            {
                return _onLoan;
            }
            set
            {
                _onLoan = value;
            }
        }        
    }
}
