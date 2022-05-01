using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyNames
{
    public class Message
    {
        private string text;
        public Message(string txt)
        {
            text = txt;
        }
        public void Print()
        {
            Console.WriteLine(text);
        }
    }
}
