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
		private bool isGameOver;
		private bool gameEnd;

		public bool IsGameOver
		{
			get { return this.isGameOver; }
			private set { this.isGameOver = value; }
		}

		public GameEngine()
		{
			isGameOver = true;
		}

		public void Restart()
		{
			gameEnd = true;
		}

		public void Exit()
		{
			isGameOver = false;
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
			gameEnd = false;
			string inputString = "";
			while (!gameEnd)
			{
				consoleRenderer.RenderMatrix(currentMatrix);
				if (equalMatrixChecker.IsSorted(currentMatrix))  // IsGameWon check
				{
					consoleRenderer.PrintGameWon(playerMoves);

					consoleRenderer.Print("Please enter your name for the top scoreboard: ");
					string playerName = "";
					while (true)
					{
						playerName = consoleReader.Read();
						if (!string.IsNullOrEmpty(playerName))
						{
							break;
						}
						consoleRenderer.Print("Please enter a non empty name: ");
					}

					Player currentPlayer = new Player(playerName, playerMoves);
					scoreboard.AddPlayer(currentPlayer);

					consoleRenderer.RenderScoreboard(scoreboard);
					return;
				}

				consoleRenderer.Print("Enter a number to move: ");
				inputString = consoleReader.Read();

				switch (inputString)
				{
					case "exit":
						consoleRenderer.PrintLine("Good bye!");
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
						currentCommand = new DefaultCommand(currentMatrix, consoleRenderer, emptyPoint, inputString);
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