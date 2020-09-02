using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Kino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome player!");
            Console.WriteLine("Choose your bet carefully");
            Console.WriteLine("Odd and Even numbers win x2");
            Console.WriteLine("Draw wins x4");
           
            Random randomNumber = new Random();
            Kino game = new Kino();
            game.startOfGame(randomNumber);

        }
    }
}
