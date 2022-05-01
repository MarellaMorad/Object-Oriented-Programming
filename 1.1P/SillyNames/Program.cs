using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SillyNames
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[4];
            string name;

            myMessage = new Message("Hello World");
            myMessage.Print();

            messages[0] = new Message("What a Wonderful name!");
            messages[1] = new Message("WOW, I love your name.");
            messages[2] = new Message("Such an interesting name, what does it mean?");
            messages[3] = new Message("No for real, this can't be your name!");

            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            if (name.ToLower() == "marella")
            {
                messages[0].Print();
            }
            else if (name.ToLower() == "christy")
            {
                messages[1].Print();
            }
            else if (name.ToLower() == "sama")
            {
                messages[2].Print();
            }
            else
            {
                messages[3].Print();
            }

            //added these two lines because the program would perform everything and close before being able to read the output
            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }
}
