using System;
using System.Collections.Generic;

namespace Unit03
{
    /// <summary>
    /// <para> The jumper/parachute design. </para>
    /// <para>
    /// The responsibility of Jumper is to display the parachute.
    /// </para>
    /// </summary>
    public class Jumper
    {
        private List<string> parachute = new List<string>();
        
        public Jumper()
        {
            jump();
        }

        /// <summary>
        /// Displays jumper/parachute layout.
        /// </summary>
        public void jump()
        {
            parachute.Clear();
            parachute.Add("  ___   ");
            parachute.Add(" /___\\ ");
            parachute.Add(" \\   / ");
            parachute.Add("  \\ /  ");
            parachute.Add("   O    ");
            parachute.Add("  /|\\  ");
            parachute.Add("  / \\  ");
        }

        /// <summary>
        /// Updates the parachute status.
        /// </summary>
        public void Update()
        {
            TerminalService.WriteList(parachute);
        }
        
        /// <summary>
        /// Cuts the rope when the user gives a wrong answer
        /// </summary>
        public void CutRope() 
        {
            if (parachute.Count > 3)
            {
                parachute.RemoveAt(0);
            }
            if (parachute.Count == 3)
            {
                parachute[0] = "   x    ";
            }
            Update();
        }

        /// <summary>
        /// Determines if the jumper is alive
        /// </summary>
        public bool IsAlive()
        {
            return parachute.Count > 3;
        }
    }
}    
