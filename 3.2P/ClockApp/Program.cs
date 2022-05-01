using System;

namespace ClockApp
{
    class Program
    {
        static void Main()
        {
            Clock clock = new Clock();
            /*
             * 46824/3600 = 13.00667                --> hours = 13
             * 13.00667 - 13 = 0.00667 * 60 = 0.4   --> minutes = 00
             * 0.4 * 60 = 24                        --> seconds = 24
             */
            for(int i = 0; i < 46824; i++)
            {
                clock.Tick();
            }

            Console.WriteLine("First Try...");
            Console.WriteLine("Expected Output: 13:00:24");
            Console.WriteLine("Actual Output: {0}", clock.Time);
            Console.WriteLine();

            clock.Reset();

            for (int i = 0; i < 23104; i++)
            {
                clock.Tick();
            }

            Console.WriteLine("Second Try...");
            Console.WriteLine("Expected Output: 06:25:04");
            Console.WriteLine("Actual Output: {0}", clock.Time);
        }
    }
}
