using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Syntax for a do-while loop:

            // string input;
            // do
            // {
            //    Console.Write("Do you want to continue? ");
            //    input = Console.ReadLine(); 
            // } while (input == "yes");

            // Syntax for a for loop
            // (is more like a "for x in range" loop in Python)

            // The following code shows the syntax of a for loop that counts from 0 to 9.

            // for (int i = 0; i < 10; i++) ++ operator increments the value in the variable by one.
            // {
            //     Console.WriteLine(i);
            // }

            // Syntax for a foreach loop
            // (similar to a standard for loop in Python)

            // foreach (string color in colors)
            // {
            //     Console.WriteLine(color);
            // }
        
            Console.WriteLine("This is Prep 3");

            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11);

            Console.Write("Guess the magic number between one and 10: ");
            int guess = int.Parse(Console.ReadLine());

            int magicNumber = -1;
            while (magicNumber != number)
            {
                 Console.Write("Guess the magic number: ");
                 magicNumber = int.Parse(Console.ReadLine());

                 if (number > magicNumber)
                 {
                     Console.WriteLine("Higher");
                 }
                 else if (number < magicNumber)
                 {
                     Console.WriteLine("Lower");
                 }
                 else
                 {
                     Console.WriteLine("That is correct! Yay!");
                 }
            }


        }   
    }
}
