namespace RecursionAndBacktracking
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static List<string> directions = new List<string>();

        public static void Main()
        {
            var lab = ReadLab();
            FindPaths(lab, 0, 0, directions, string.Empty);
        }

        public static char[,] ReadLab()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string inputLab = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = inputLab[col];
                }
            }

            return labyrinth;
        }

        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0)
                || col < 0 || col >= matrix.GetLength(1);
        }

        public static void FindPaths(
            char[,] matrix,
            int row,
            int col,
            List<string> directions,
            string direction)
        {
            if (IsInRange(matrix, row, col)) 
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = 'v';

            FindPaths(matrix, row - 1, col, directions, "U");
            FindPaths(matrix, row + 1, col, directions, "D");
            FindPaths(matrix, row , col - 1, directions, "L");
            FindPaths(matrix, row , col + 1, directions, "R");

            matrix[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }
    }
}