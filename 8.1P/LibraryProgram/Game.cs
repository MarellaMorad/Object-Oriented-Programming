using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryProgram
{
    public class Game : LibraryResource
    {
        private string _contentRating;
        private string _developer;

        public Game(string name, string creator, string rating) : base(name, creator)
        {
            //initialise delveloper and content rating fields with given parameters
            _developer = creator;
            _contentRating = rating;
        }

        //ContentRating readonly property
        public string ContentRating
        {
            get
            {
               return _contentRating;
            }
        }

        //Creator override readonly property
        public override string Creator
        {
            get
            {
                return _developer;
            }
        }
    }
}
