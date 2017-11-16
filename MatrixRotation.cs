using System;
namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solve();

            // tests
            var matrix = new[,] { { 0, 7, 6 }, { 1, 8, 5 }, { 2, 3, 4 } };

            int rows = matrix.GetLength(0);  // row
            int cols = matrix.GetLength(1);  // column 
            PrintMatrix(rows,cols,matrix);
            Rotate(matrix, 1);
            PrintMatrix(rows, cols, matrix);
        }

        public static void Solve()
        {
            // input - 3 numbers. 1- rows count, 2 - cols count, 3 - count of rotations
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            int row = Convert.ToInt32(arr[0].Trim());
            int col = Convert.ToInt32(arr[1].Trim());
            int rotations = Convert.ToInt32(arr[2].Trim());

            int[,] matrix = new int[row, col];
            int[][] mx = new int[row][];

            for (int i = 0; i < row; i++)
            {
                mx[i] = GetInts(Console.ReadLine(), col);
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = mx[i][j];
                }
            }

            //PrintMatrix(row, col, matrix);

            Rotate(matrix, rotations);

            PrintMatrix(row, col, matrix);
        }

        private static void PrintMatrix(int row, int col, int[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                string s = "";
                for (int j = 0; j < col; j++)
                    s += matrix[i, j] + " ";
                Console.WriteLine(s.Trim());
            }
        }

        static int[] GetInts(string inp, int cnt)
        {
            string[] vals = inp.Split(new char[] { ' ' });
            int[] res = new int[cnt];
            for (int i = 0; i < cnt; i++)
            {
                res[i] = Convert.ToInt32(vals[i]);
            }
            return res;
        }

        public static bool Rotate(int[,] matrix, int steps)
        {
            if (matrix == null) return false;

            int rows = matrix.GetLength(0);  // row
            int cols = matrix.GetLength(1);  // column 

            int startRow = 0;
            int startCol = 0;

            while (rows > 1 && cols > 1)
            {
                int circleLength = 2 * rows + 2 * cols - 4;
                int actualSteps = steps % circleLength;

                // rotate step by step
                for (int step = 0; step < actualSteps; step++)
                {
                    int ltCorner = matrix[startRow, startCol];

                    for (int colIndex = startCol; colIndex < startCol + cols - 1; colIndex++)
                    {
                        matrix[startRow, colIndex] = matrix[startRow, colIndex + 1];
                    }

                    int lastCol = startCol + cols - 1;
                    for (int rowIndex = startRow; rowIndex < startRow + rows - 1; rowIndex++)
                    {
                        matrix[rowIndex, lastCol] = matrix[rowIndex + 1, lastCol];
                    }

                    int lastRow = startRow + rows - 1;
                    for (int colIndex = startCol + cols - 1; colIndex >= startCol + 1; colIndex--)
                    {
                        matrix[lastRow, colIndex] = matrix[lastRow, colIndex - 1];
                    }

                    for (int rowIndex = startRow + rows - 1; rowIndex >= 1 + startRow; rowIndex--)
                    {
                        matrix[rowIndex, startCol] = matrix[rowIndex - 1, startCol];
                    }

                    matrix[startRow + 1, startCol] = ltCorner;
                }

                startRow++;
                startCol++;

                rows -= 2;
                cols -= 2;
            }

            return true;
        }
    }
}
