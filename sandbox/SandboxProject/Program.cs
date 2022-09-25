// Juliana J. Lemos
// Developer/Unit01 project: Tic-Tac-Toe
// Instructor: Brother Burton

using System;
using System.Collections.Generic;
namespace SandboxProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Menu
            Console.WriteLine("********************************");
            Console.WriteLine("WELCOME TO TIC-TAC-TOE!");
            Console.WriteLine("********************************");
            Console.Write("Would you like to check the instructions (y/n)? ");
            string answer = Console.ReadLine();
            string yesAnswer = "y";

            // Function to print the instructions
            static void DisplayInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("The game is played on a grid that is three squares by three squares.");
            Console.WriteLine("Players take turns putting their marks (x and o) in empty squares.");
            Console.WriteLine("The first player to get three of their marks in a row is the winner.");
            Console.WriteLine("");
            Console.WriteLine("Okay! Let's play!");
        }
        
            if ((answer == yesAnswer))
            {
                DisplayInstructions(); 
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Okay! Let's play!");
                Console.WriteLine("");
            }

            List<string> board = GetNewBoard();
            string playingNow = "x";
            
            while (!EndOfTheGame(board))
            {
                DisplayBoard(board);
                int choice = GetMoveChoice(playingNow);
                MakeMove(board, choice, playingNow);

                playingNow = GetNextPlayer(playingNow);

            }
            DisplayBoard(board);
            Console.WriteLine("");
            Console.WriteLine("Thanks for playing!");
        }

        static void DisplayBoard(List<string> board) // game Interface
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}"); // The board starts with a zero due to the index.
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            Console.WriteLine("");
        }

        static List<string> GetNewBoard()
        {
            // List to hold the numbers of the board
            List<string> board = new List<string>();
            board.Add("1");
            board.Add("2");
            board.Add("3");
            board.Add("4");
            board.Add("5");
            board.Add("6");
            board.Add("7");
            board.Add("8");
            board.Add("9");
            
            return board;
        }
           static bool EndOfTheGame(List<string> board) // The game is over when someone wins or when we have a tie
        {
            bool EndOfTheGame = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                EndOfTheGame = true;
            }

            return EndOfTheGame;
        }
         static bool IsWinner(List<string> board, string player)
        {
            bool isWinner = false;

            // The if checks a win
            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                isWinner = true;
            }

            return isWinner; 
        }
        static bool IsTie(List<string> board) // If the board is complete, the game is over
        {
        
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }
           static string GetNextPlayer(string playingNow) // switch between players
        {
            string nextPlayer = "x";

            if (playingNow == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }
         static int GetMoveChoice(string playingNow)
        {
            Console.Write($"{playingNow}, it's your turn! Go ahead and choose a square (1-9): ");
            string move_string = Console.ReadLine();
            Console.WriteLine("");

            int choice = int.Parse(move_string); // Converts a integer into a string
            return choice;
        }
         
         static void MakeMove(List<string> board, int choice, string playingNow)
        {
            int index = choice - 1; //This section of the code ensures that the user's choice represents a correct number in the board.
            board[index] = playingNow;
        }
    }
}
