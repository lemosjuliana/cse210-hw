using System;
using System.Collections.Generic;

namespace Prep5
{
    class Program
    {
        static void Main(string[] args)
        {

            // each function must define its return type
            // each parameter must have a data type as well
            // a function name should use "Title Case"
            // ex:

            // returnType FunctionName(dataType parameter1, dataType parameter2)
            // {
                // -> function_body
            //}

            // void DisplayMessage() -> function that does not have parameters or a return type
            // {
            //     Console.WriteLine("Hello world!");
            // }

            // void DisplayPersonalMessage(string userName) -> a function that accepts a single string parameter
            // {
            //     Console.WriteLine($"Hello {userName}");
            // }

            // int AddNumbers(int first, int second) -> a function that accepts two integers as parameters. 
            // {
            //      int sum = first + second;
            //      return sum;
            // }

            // In C#, because the language is so dedicated to the principles of programming with Classes, 
            // the default case for all functions is to be methods, which must be called in the context of an object.

            // If you want to define "regular" standalone function, you need to use the static keyword.
            // ex: 

            // static int AddNumbers(int first, int second)
            // {
            //     int sum = first + second;
            //     return sum;
            // }   

            Console.WriteLine("This is Prep 5");

            DisplayMessage();

            string userName = PromptUserName();
            int userNumber = DisplayUserNumber();
            int squaredNumber = SquaredNumber(userNumber);
            DisplayResult(userName, squaredNumber);

        }

        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int DisplayUserNumber()
        {
            Console.Write("Please enter a number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        static int SquaredNumber(int number)
        {
            int square = number * number;
            return square;
        }

        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name}, the square of your number is {square}");
        }

    
    }
}
