namespace GameFifteen.Common
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    public class GameEngine
    {
        // TODO moove common constants to game settings
        public const int GAME_BOARD_SIZE = 4;
        public static bool PlayAgain{get;private set;}
		public static bool GameEnd { get; private set; }

		public GameEngine()
		{
			PlayAgain = true;
		}

		public void Restart()
		{
			GameEnd = true;
		}

		public void Exit()
		{
			PlayAgain = false;
			Restart();
		}

		public void StartNewGame(IRenderer consoleRenderer, IReader consoleReader, Scoreboard scoreboard)
		{
            MatrixGenerator matrixGenerator = new MatrixGenerator(GAME_BOARD_SIZE);
            int[,] currentMatrix = matrixGenerator.GenerateMatrix();
            int matrixLength = currentMatrix.GetLength(0);
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(new MatrixGenerator(matrixLength));
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            Point emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            Command currentCommand;

            consoleRenderer.PrintWelcome();

            // main algorithm
            int playerMoves = 0;
			GameEnd = false;
            string inputString = "";
            while (!GameEnd)
            {
                consoleRenderer.RenderMatrix(currentMatrix);
                if (equalMatrixChecker.IsSorted(currentMatrix))  // IsGameWon check
                {
                    consoleRenderer.PrintGameWon(playerMoves);
                    consoleRenderer.AskPlayerForName();
                    string playerName = consoleReader.Read();
                    Player currentPlayer = new Player(playerName, playerMoves);
                    scoreboard.AddPlayer(currentPlayer);
                    consoleRenderer.RenderScoreboard(scoreboard);
                    return;
                }

                Console.Write("Enter a number to move: ");
                inputString = consoleReader.Read();

                switch (inputString)
                {
                    case "exit":
                        Console.WriteLine("Good bye!");
                        currentCommand = new ExitCommand(this);
                        currentCommand.Execute();
                        break;
                    case "restart":
                        currentCommand = new RestartCommand(this);
                        currentCommand.Execute();
                        break;
                    case "top":
                        currentCommand = new ShowScoreboardCommand(consoleRenderer, scoreboard);
                        currentCommand.Execute();
                        break;
                    default:
                        currentCommand = new DefaultCommand(currentMatrix,consoleRenderer,emptyPoint,inputString);
                        currentCommand.Execute();
                        if ((currentCommand as DefaultCommand).IsPlayerMoved)
                        {
                            playerMoves++;
                        }
                        break;
                }

            }
        }     
    }
}