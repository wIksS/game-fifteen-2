namespace GameFifteen.Common
{
    using System;

    /// <summary>Represents a point.</summary>
    public class Point : ICloneable
    {
        private int row;
        private int col;

        /// <summary>Constructor.</summary>
        /// <param name="row" type="int">The row.</param>
        /// <param name="col" type="int">The column.</param>
        public Point(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        /// <summary>Gets or sets the row.</summary>
        /// <value>The row.</value>
        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        /// <summary>Gets or sets the col.</summary>
        /// <value>The column.</value>
        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        /// <summary>Makes a deep copy of this object.</summary>
        /// <returns>A copy of this object.</returns>
        public object Clone()
        {
            return new Point(this.Row, this.Col);
        }
    }
}
