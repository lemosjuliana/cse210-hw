using System;
using System.Collections.Generic;

namespace Unit03
{
    /// <summary>
    /// <para>A service that handles terminal operations.</para>
    /// <para>
    /// The responsibility of a TerminalService is to provide input and output operations for the 
    /// terminal.
    /// </para>
    /// </summary>
    public class TerminalService
    {
        /// <summary>
        /// Constructor is private since we have only static members
        /// </summary>
        private TerminalService() 
        {
            // NOPE
        }
        /// <summary>
        /// Gets numerical input from the terminal. Directs the user with the given prompt.
        /// </summary>
        /// <param name="prompt">The given prompt.</param>
        /// <returns>Inputted number.</returns>
        public static int ReadNumber(string prompt)
        {
            string rawValue = ReadText(prompt);
            return int.Parse(rawValue, System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets text input from the terminal. Directs the user with the given prompt.
        /// </summary>
        /// <param name="prompt">The given prompt.</param>
        /// <returns>Inputted text.</returns>
        public static string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Obtains the next character or function key pressed by the user. The pressed key is optionally displayed
        /// in the console window.
        /// </summary>
        /// <param name="noDisplay">If true, will prevent the character to be displayed on the console window.</param>
        /// <returns>Inputted character.</returns>
        public static Char ReadChar(bool noDisplay)
        {
            return Console.ReadKey(noDisplay).KeyChar;
        }

        /// <summary>
        /// Wait for a key to be pressed on the console window. The key will not be displayed.
        /// </summary>
        /// <param name="noDisplay">If true, will prevent the character to be displayed on the console window.</param>
        public static void WaitForKey()
        {
            Console.ReadKey(true);
        }

        /// <summary>
        /// Displays the given text on the terminal and inserts a line break. 
        /// </summary>
        /// <param name="text">The given text.</param>
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Displays the given text on the terminal without line breaks. 
        /// </summary>
        /// <param name="text">The given text.</param>
        public static void WriteText(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Clears the console
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes the contents of the given list to the console
        /// </summary>
        /// <param name="text">The given list.</param>
        public static void WriteList(List<String> list)
        {
            foreach (String line in list)
            {
                Console.WriteLine(line);   
            }
        }
    }
}