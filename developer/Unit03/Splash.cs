using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{   
    /// <summary>
    /// <para> The "splash" animation for the game. </para>
    /// <para>
    /// The responsibility of Splash is to display the game's splash.
    /// </para>
    /// </summary>
    public class Splash
    {
        /// <summary>
        /// Constructor is private since we have only static methods.
        /// </summary>
        private Splash() 
        {
            // This is left empty
        }
        
        /// <summary>
        /// Shows the "splash" for the game and waits for a key being pressed.
        /// </summary>
        public static void show()
        {
            TerminalService.Clear();
            List<string> splashList = new List<string>(File.ReadLines("splash.txt"));
            foreach (string line in splashList)
            {
                TextAnimator.WriteLine(line, 15);
            }
            TerminalService.WaitForKey();
            TerminalService.Clear();
        }
    }
}