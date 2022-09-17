using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {   

            // you not only declare that it is a List, you also declare the type of data that can be put in the list.
            // ex: List<string> words = new List<int>();

            // Adding items -> .Add()
            // ex: words.Add("phone");

            // Getting the List size -> Count
            // ex: Console.WriteLine(words.Count);

            // Interating through a List using foreach loop
            // ex:

            // foreach (string word in words)
            // {
            //     Console.WriteLine(word);
            // }

            // Access items by index
            // ex:

            // for (int i = 0; i < words.Count; i++)
            // {
            //     Console.WriteLine(words[i]);
            // }

            Console.WriteLine("This is Prep 4");

            int number = -1;

            List<int> numbers = new List<int>();
            
            while (number != 0)
            {
                Console.WriteLine("Enter a list of numbers, type 0 when finished.");
                string answer = Console.ReadLine();
                number = int.Parse(answer);
                numbers.Add(number);
            }

            int sum = 0;
            foreach (int item in numbers)
            {
                sum += item;
            }

            Console.Write($"The sum is {sum}.");

            float average = sum/numbers.Count;
            Console.WriteLine($"The average is {average}.");

            int max = numbers[0];
            foreach (int item in numbers)
            {
                if (item>max)
                {
                    max = item;
                }
            }

            Console.WriteLine($"The max is {max}.");

        }
    }
}
