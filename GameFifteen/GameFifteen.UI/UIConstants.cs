namespace GameFifteen.UI
{
    using System;

    internal static class UIConstants
    {
        internal const string EMPTY_SCOREBOARD_MESSAGE = "Scoreboard is empty";
        internal const string SCOREBOARD = "Scoreboard:";
        internal const string SCORE_RESULT_FORMAT = "{0}. {1} --> {2} moves";
        internal const string WELCOME_MESSAGE = "Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.";
        internal const string CONGRATULATIONS_MESSAGE = "Congratulations! You won the game in {0} moves.";
        internal const string NEW_LINE = "\n";
    }
}
