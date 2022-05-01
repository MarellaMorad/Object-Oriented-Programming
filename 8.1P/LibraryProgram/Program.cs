using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Marella's Library");

            //First book
            Book GameOfThrones = new Book("Game of Thrones", "George R. R. Martin", "9780007237500");
            //Second book
            Book LordofRings = new Book("The Lord of the Rings", "J. R. R. Tolkien", "9780007141326");
            //Third book
            Book PAndP = new Book("Pride and Prejudice", "Jane Austen", "9783839893876");

            //First Game
            Game Fifa = new Game("FIFA", "EA Sports", "PEGI 3");
            //Second Game
            Game ItTakes2 = new Game("It Takes Two", "Hazelight Studios", "PEGI 12");
            //Third Game
            Game Pubg = new Game("PUBG", "PUBG Corporation", "16+");

            //Adding the books and games to the library
            library.AddResources(Pubg);
            library.AddResources(ItTakes2);
            library.AddResources(Fifa);
            library.AddResources(PAndP);
            library.AddResources(LordofRings);
            library.AddResources(GameOfThrones);

            //putting game of thrones and pubg on loan
            GameOfThrones.OnLoan = true;
            Pubg.OnLoan = true;

            //It takes two is not on loan
            Console.WriteLine(library.HasResource("It Takes Two"));

            //Game of Thrones is on loan
            Console.WriteLine(library.HasResource("Game of Thrones"));
            
        }
    }
}
