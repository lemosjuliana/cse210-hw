 namespace Unit02
{
    public class Hilo 
    {
      /// <summary>
      /// Starts the program using the given arguments.
      /// </summary>
      /// <param name="args">The given arguments.</param>
      static void Main(string[] args)
      {
          // an instance of the Game class is created and 
          // assigned to a variable called game
            Game game = new Game();
            game.run();
      }
    }  
} 