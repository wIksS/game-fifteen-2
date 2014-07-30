namespace GameFifteen.Logic
{
    using GameFifteen.Contracts;
    using GameFifteen.Utils;
    using GameFifteen.UI;
    using GameFifteen.Common;

    /// <summary>Represents a game engine.</summary>
    public class GameEngine
    {
        private bool isGameOver;
        private bool gameEnd;

        private IRenderer renderer;
        private IReader inputReader;
        private Scoreboard scoreboard;
        private INumberGenerator numberGenerator;

        /// <summary>Gets or sets a value indicating whether this object is game over.</summary>
        /// <value>true if this object is game over, false if not.</value>
        public bool IsGameOver
        {
            get { return this.isGameOver; }
            private set { this.isGameOver = value; }
        }

        /// <summary>Default constructor.</summary>
        public GameEngine()
        {
            isGameOver = true;

            renderer = new ConsoleRenderer();
            inputReader = new ConsoleReader();
            scoreboard = Scoreboard.Instance;
            numberGenerator = new NumberGenerator(CommonConstants.GAME_BOARD_SIZE * CommonConstants.GAME_BOARD_SIZE);
        }

        /// <summary>Restarts this object.</summary>
        public void Restart()
        {
            gameEnd = true;
        }

        /// <summary>Exits the given console renderer.</summary>
        /// <param name="consoleRenderer" type="IRenderer">The console renderer.</param>
        public void Exit(IRenderer consoleRenderer)
        {
            consoleRenderer.PrintLine(CommonConstants.GOODBYE);
            isGameOver = false;
            Restart();
        }

        /// <summary>Starts new game.</summary>
        public void StartNewGame()
        {
            IMatrixGenerator matrixGenerator = new MatrixGenerator(CommonConstants.GAME_BOARD_SIZE, this.numberGenerator);
            int[,] currentMatrix = matrixGenerator.GenerateMatrix();
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            Point emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            Command currentCommand;

            this.renderer.PrintWelcome();

            // main algorithm
            int playerMoves = 0;
            gameEnd = false;
            string inputString = "";
            while (!gameEnd)
            {
                this.renderer.RenderMatrix(currentMatrix);
                if (equalMatrixChecker.IsSorted(currentMatrix))  // IsGameWon check
                {
                    this.renderer.PrintGameWon(playerMoves);

                    this.renderer.Print(CommonConstants.PLAYER_NAME);
                    string playerName = "";
                    while (true)
                    {
                        playerName = this.inputReader.Read();
                        if (!string.IsNullOrEmpty(playerName))
                        {
                            break;
                        }
                         this.renderer.Print(CommonConstants.NON_EMPTY_PLAYER_NAME);
                    }

                    Player currentPlayer = new Player(playerName, playerMoves);
                    scoreboard.AddPlayer(currentPlayer);

                     this.renderer.RenderScoreboard(scoreboard);
                    return;
                }

                this.renderer.Print(CommonConstants.NUMBER_TO_MOVE);
                inputString = this.inputReader.Read();

                switch (inputString)
                {
                    case "exit":
                        currentCommand = new ExitCommand( this.renderer, this);
                        break;
                    case "restart":
                        currentCommand = new RestartCommand(this);
                        break;
                    case "top":
                        currentCommand = new ShowScoreboardCommand( this.renderer, scoreboard);
                        break;
                    default:
                        currentCommand = new DefaultCommand(currentMatrix,  this.renderer, emptyPoint, inputString);
                        break;
                }

                currentCommand.Execute();

                if (currentCommand is DefaultCommand && (currentCommand as DefaultCommand).IsPlayerMoved)
                {
                    playerMoves++;
                }
            }
        }
    }
}