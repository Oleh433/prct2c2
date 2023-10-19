using System.Text;

namespace prc2
{
    public partial class MyMatrix
    {
        private double[,] matrix;

        public int Height => matrix.GetLength(0);

        public int Width => matrix.GetLength(1);

        public double this[int row, int column]
        {
            get
            {
                if (AreInvalidInputIndexes(row, column))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return matrix[row, column];
            }
            set
            {
                if (AreInvalidInputIndexes(row, column))
                {
                    throw new ArgumentOutOfRangeException();
                }

                matrix[row, column] = value;
            }
        }

        public double[,] Matrix
        {
            get { return matrix; }
        }

        public MyMatrix(int rows, int columns)
        {
            if (AreInvalidInputIndexes(rows, columns))
            {
                throw new ArgumentOutOfRangeException();
            }

            matrix = new double[rows, columns];
        }

        public MyMatrix(MyMatrix other)
        {
            matrix = other.Matrix;
        }

        public MyMatrix(double[,] other)
        {
            matrix = other;
        }

        public MyMatrix(double[][] other)
        {
            if (other == null || other.Length == 0 || other[0] == null || other[0].Length == 0)
            {
                throw new ArgumentException("Invalid input array.");
            }

            int numRows = other.Length;
            int numCols = other[0].Length;

            for (int i = 1; i < numRows; i++)
            {
                if (other[i].Length != numCols)
                {
                    throw new ArgumentException("Input array should have consistent row lengths.");
                }
            }

            matrix = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = other[i][j];
                }
            }
        }

        public MyMatrix(string[]? rows)
        {
            if (rows == null || rows.Length == 0)
            {
                throw new ArgumentException("Input rows cannot be empty or null.");
            }

            int numRows = rows.Length;
            int numCols = rows[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                string[] rowValues = rows[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (rowValues.Length != numCols)
                {
                    throw new ArgumentException("All rows must have the same number of columns.");
                }

                for (int j = 0; j < numCols; j++)
                {
                    if (!double.TryParse(rowValues[j], out matrix[i, j]))
                    {
                        throw new ArgumentException("Invalid numeric value in the input.");
                    }
                }
            }
        }

        public double getElement(int row, int column)
        {
            if (AreInvalidInputIndexes(row, column))
            {
                throw new ArgumentOutOfRangeException();
            }

            return matrix[row, column];
        }

        public void setElement(int row, int column, double value)
        {
            if (AreInvalidInputIndexes(row, column))
            {
                throw new ArgumentOutOfRangeException();
            }

            matrix[row, column] = value;
        }

        public override string ToString()
        {
            StringBuilder result = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result.Append($"{matrix[i, j]}\t");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private bool AreInvalidInputIndexes(int row, int column)
        {
            return Height < row || Width < column || row < 0 || column < 0;
        }
    }
}