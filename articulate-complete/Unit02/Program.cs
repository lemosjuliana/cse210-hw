using Unit02.Game;


namespace Unit02
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // an instance of the Director class is created and 
            // assigned to a variable called director
            Director director = new Director();
            director.StartGame();
        }
    }
}
