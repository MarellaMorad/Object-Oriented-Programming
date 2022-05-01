using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    public class Book : LibraryResource
    {
        private string _isbn;
        private string _author;

        public Book(string name, string creator, string isbn) : base(name, creator)
        {
            //initialise the isbn and author fields with given parameters
            _isbn = isbn;
            _author = creator;
        }

        //ISBN readonly property
        public string ISBN
        {
            get
            {
                return _isbn;
            }
        }

        //Creator override readonly property
        public override string Creator
        {
            get
            {
                return _author;
            }
        }
    }
}
