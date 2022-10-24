using System.Threading;

namespace Unit03
{
    /// <summary>
    /// <para> A utility class that provides general utility services (work in progress). </para>
    /// <para>
    /// The responsibility of GameUtils is to keep track of the game utilities.
    /// </para>
    /// </summary>
    public class GameUtils
    {
        /// <summary>
        /// Constructor is private since we have only static methods.
        /// </summary>
        private GameUtils() 
        {
            // This is left empty
        }

        /// <summary>
        /// Pause the process being executed for some time.
        /// It is used to create some text animation effects.
        /// </summary>
        public static void Wait(int millis)
        {
            Thread.Sleep(millis);
        }
    }
}