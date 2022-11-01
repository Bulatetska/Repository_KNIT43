using System;

namespace project_1
{

    enum RockPaperScissors
    {
        Rock,
        Paper,
        Scissors
    }




    class Game
    {
        public struct GameInfo
        {
            public int GamesPlayed;
        }
        public static GameInfo Info = new GameInfo();

        static void Main()
        {
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            Participant comp = new Computer();
            Participant player = new Player();
            RockPaperScissors computerSelection;
            RockPaperScissors playerSelection;
            ConsoleKeyInfo input;
            bool playAgain;

            do
            {
                Console.Clear();
                computerSelection = comp.Select();
                playerSelection = player.Select();
                Console.Clear();

                Console.WriteLine("Player: " + playerSelection);
                Console.WriteLine("\n" + "Computer: " + computerSelection);

                switch (determineWinner((int)computerSelection, (int)playerSelection))
                {
                    case null:
                        Console.Write("\n it's a tie");
                        break;

                    case true:
                        Console.Write("\n you won!");
                        player.wins++;
                        break;

                    default:
                        Console.Write("\n you lost");
                        comp.wins++;
                        break;
                }

                Game.Info.GamesPlayed++;
                Console.WriteLine("\n" + "Play again? <y/n>");
                Console.WriteLine("\n");

                int resetPosY = Console.CursorTop;
                int resetPosX = Console.CursorLeft;

                Console.SetCursorPosition(30, 0);
                player.PrintWinRate();
                Console.SetCursorPosition(30, 2);
                comp.PrintWinRate();
                Console.SetCursorPosition(resetPosX, resetPosY);

                input = Console.ReadKey(true);
                playAgain = input.KeyChar == 'y';

            } while (playAgain);
        }
        public static bool? determineWinner(int playerSelection, int computerSelection)
        {

            bool?[,] winMatrix = {
            {null, false, true },
            {true, null, false },
            {false, true, null}
        };

            if (winMatrix[playerSelection, computerSelection] == null)
                return null;
            return (winMatrix[playerSelection, computerSelection] == true) ? false : true;
        }
    }
}