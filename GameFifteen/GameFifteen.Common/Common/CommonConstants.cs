namespace GameFifteen.Common
{
    using System;

    internal static class CommonConstants
    {
        internal const int MAX_PLAYERS_IN_SCOREBOARD = 5;
        internal const int INITIAL_MATRIX_NUMBER = 1;
        internal const int GAME_BOARD_SIZE = 4;
        internal const int INIT_POINT_POSITION = GAME_BOARD_SIZE - 1;
        internal const int MIN_MOOVES_RANDOM_NUMBER = 10;
        internal const int MAX_MOOVES_RANDOM_NUMBER = 20;

        internal const int INITIAL_EMPTY_CELL = GAME_BOARD_SIZE * GAME_BOARD_SIZE;

        internal const string INVALID_PLAYER = "Player cannot be null.";
        internal const string INVALID_PLAYER_NAME = "Name must be a non - empty string.";
        internal const string NEGATIVE_MOVE = "Moves cannot be negative.";
        internal const string PLAYER_NAME = "Please enter your name for the top scoreboard: ";
        internal const string NON_EMPTY_PLAYER_NAME = "Please enter a non empty name: ";
        internal const string NUMBER_TO_MOVE = "Enter a number to move: ";
        internal const string GOODBYE = "Good bye!";
        internal const string INVALID_MOVE = "Invalid move";
        internal const string INVALID_NUMBER = "Invalid number";
        internal const string INVALID_COMMAND = "Invalid command";
    }
}
