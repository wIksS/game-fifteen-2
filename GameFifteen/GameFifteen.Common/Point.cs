﻿namespace GameFifteen.Common
{
    public class Point
    {
        private int row;
        private int col;

        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }
    }
}
