using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLo_Game
{
    class Program
    {
        const int Low = 1;
        const int High = 100;
        const int Exit = -1;

        static void Main(string[] args)
        {
            Random rng = new Random();
            char Restart = 'Y';
            bool EndGame = false;
            int Target = 0;
            int Guess = 0;

            Console.WriteLine("Welcome to the HiLo Game, Please enter your Username: ");
            String UserName = Console.ReadLine();

            do
            {
                Console.Clear();
                Target = rng.Next(Low, (High + 1));
                EndGame = false;

                Console.WriteLine("\n\nI'm thinking of a number between " + Low + " and " + High + ".");
                Console.WriteLine("Can you guess the number? " + UserName + " \n");
                while (!EndGame)
                {
                    Console.Write("Make your guess between " + Low + " & " + High + " or hit (" + Exit + " to quit) ==> ");
                    Guess = ValidateInput();

                    if (Guess == Exit)
                    {
                        Console.WriteLine( UserName + " You gave up? Really?");
                        EndGame = true;
                    }
                    else if (Guess < Target)
                    {
                        Console.WriteLine("\n\t" + UserName + " Your guess is too low - please try again...\n");
                    }
                    else if (Guess > Target)
                    {
                        Console.WriteLine("\n\t" + UserName + " Your Guess is too high - please try again...\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\n\tWow - I can't believe you finally guessed the number. Congratulations " + UserName);
                        EndGame = true;
                    }
                }

                Console.Write("\n\nWanna play again? ");
                Console.Write("\n\nIf so please press Y. Otherwise press any other key. . . ");
                Restart = Char.ToUpper((Console.ReadLine())[0]);
            } while (Restart == 'Y');
            Console.WriteLine("Come back and Play Again sometime " + UserName);
            Console.WriteLine("Please press any key to exit. . .");
            Console.ReadKey();
        }

        private static int ValidateInput()
        {
            int input = 0;

            do
            {
                if (!Int32.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("Invalid input. Whole numbers between " + Low + " and " + High + " only.");
                    Console.Write("Try again (" + Exit + " to quit) ==> ");
                }
                else
                {
                    if (input != Exit && (input < Low || input > High))
                    {
                        Console.WriteLine("Out of bounds. Must be between " + Low + " and " + High + " only.");
                        Console.Write("Try again (" + Exit + " to quit) ==> ");
                    }
                }
            } while (input != Exit && (input < Low || input > High));

            return input;
        }
    }
}
