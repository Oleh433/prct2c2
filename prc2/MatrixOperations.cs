using prc2.Helpers;

namespace prc2
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix? left, MyMatrix? right)
        {
            MatrixValidator.Validate(left, right);

            int rows = left.Height;
            int columns = left.Width;
            MyMatrix result = new MyMatrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = left[i, j] + right[i, j];
                }
            }

            return result;
        }

        public static MyMatrix operator *(MyMatrix? left, MyMatrix? right)
        {
            MatrixValidator.Validate(left, right);

            int rows = left.Height;
            int columns = right.Width;
            int commonDimension = left.Width;
            MyMatrix result = new MyMatrix(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < commonDimension; k++)
                    {
                        sum += left[i, k] * right[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public MyMatrix GetTransponedCopy()
        {
            double[,] transposedArray = GetTransponedArray();
            return new MyMatrix(transposedArray);
        }

        public void TransponeMe()
        {
            double[,] transposedArray = GetTransponedArray();
            matrix = transposedArray;
        }

        private double[,] GetTransponedArray()
        {
            int rows = Height;
            int columns = Width;
            double[,] transposedArray = new double[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    transposedArray[i, j] = this[j, i];
                }
            }

            return transposedArray;
        }
    }
}