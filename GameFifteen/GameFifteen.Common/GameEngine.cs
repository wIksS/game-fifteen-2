namespace GameFifteen.Common
{
	using GameFifteen.Common.Contracts;
	using GameFifteen.Common.Utils;

	public class GameEngine
	{
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

		public void Exit(IRenderer consoleRenderer)
		{
			consoleRenderer.PrintLine(CommonConstants.GOODBYE);
			isGameOver = false;
			Restart();
		}

		public void StartNewGame(IRenderer consoleRenderer, IReader consoleReader, Scoreboard scoreboard)
		{
			MatrixGenerator matrixGenerator = new MatrixGenerator(CommonConstants.GAME_BOARD_SIZE);
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

					consoleRenderer.Print(CommonConstants.PLAYER_NAME);
					string playerName = "";
					while (true)
					{
						playerName = consoleReader.Read();
						if (!string.IsNullOrEmpty(playerName))
						{
							break;
						}
						consoleRenderer.Print(CommonConstants.NON_EMPTY_PLAYER_NAME);
					}

					Player currentPlayer = new Player(playerName, playerMoves);
					scoreboard.AddPlayer(currentPlayer);

					consoleRenderer.RenderScoreboard(scoreboard);
					return;
				}

				consoleRenderer.Print(CommonConstants.NUMBER_TO_MOVE);
				inputString = consoleReader.Read();

				switch (inputString)
				{
					case "exit":
						currentCommand = new ExitCommand(consoleRenderer, this);
						break;
					case "restart":
						currentCommand = new RestartCommand(this);
						break;
					case "top":
						currentCommand = new ShowScoreboardCommand(consoleRenderer, scoreboard);
						break;
					default:
						currentCommand = new DefaultCommand(currentMatrix, consoleRenderer, emptyPoint, inputString);
						break;
				}

				currentCommand.Execute();
				// type checking is bad
				if (currentCommand is DefaultCommand && (currentCommand as DefaultCommand).IsPlayerMoved)
				{
					playerMoves++;
				}
			}
		}
	}
}