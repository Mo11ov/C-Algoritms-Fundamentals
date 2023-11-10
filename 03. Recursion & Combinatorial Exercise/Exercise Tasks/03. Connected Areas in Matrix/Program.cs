namespace _03._Connected_Areas_in_Matrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public class Area
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Size { get; set; }
        }

        public static char[,] matrix;

        public static int size;

        public static char VisitedSymbol = 'v';

        public static void Main(string[] args)
        {
            matrix = ReadMatrix();

            var areas = new List<Area>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLongLength(1); c++)
                {
                    size = 0;

                    ExploreMatrix(r, c);

                    if (size > 0)
                    {
                        areas.Add(new Area() { Row = r, Col = c, Size = size});
                    }
                }
            }

            var sortedAreas = areas
                .OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();

            Console.WriteLine($"Total areas found: {sortedAreas.Count}");
            for (int i = 0; i < sortedAreas.Count; i++)
            {
                var currArea = sortedAreas[i];

                Console.WriteLine($"Area #{i + 1} at ({currArea.Row}, {currArea.Col}), size: {currArea.Size}");
            }

        }

        private static void ExploreMatrix(int r, int c)
        {
            if (IsInRange(r, c) || IsWall(r, c) || IsVisited(r, c))
            {
                return;
            }

            size += 1;
            matrix[r, c] = VisitedSymbol;

            ExploreMatrix(r - 1, c);
            ExploreMatrix(r + 1, c);
            ExploreMatrix(r, c - 1);
            ExploreMatrix(r, c + 1);
        }

        private static bool IsVisited(int r, int c)
        {
            return matrix[r, c] == VisitedSymbol;
        }

        private static bool IsWall(int r, int c)
        {
            return matrix[r, c] == '*';
        }

        private static bool IsInRange(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }

        public static char[,] ReadMatrix()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string colElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = colElements[c];
                }
            }

            return matrix;
        }
    }
}