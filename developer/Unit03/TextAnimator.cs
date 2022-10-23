namespace Unit03
{
    /// <summary>
    /// <para>A Text Animator for visual purposes</para>
    /// <para>
    /// The responsibility of TextAnimator is to animate text, specially those in splash.
    /// </para>
    /// </summary>
    public class TextAnimator
    {
        /// <summary>
        /// Constructor is private since we have only static methods
        /// </summary>
        private TextAnimator() 
        {
        }

        /// <summary>
        /// Writes line in a specific time interval.
        /// </summary>
        public static void WriteLine(string text, int interval)
        {
            foreach(char ch in text) 
            {
                TerminalService.WriteText(ch.ToString());
                if (ch != ' ')
                {
                    GameUtils.Wait(interval);
                }
            }
            TerminalService.WriteText("\n");
        }
    }
}