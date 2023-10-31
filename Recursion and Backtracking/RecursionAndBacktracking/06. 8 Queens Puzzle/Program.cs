namespace RecursionAndBacktracking
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attacktedRightDiagonal = new HashSet<int>(); 
        private static HashSet<int> attackedLeftDiagonal = new HashSet<int>();

        public static void Main()
        {
            bool[,] board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    // Pre recursive behaviour 
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonal.Add(row - col);
                    attacktedRightDiagonal.Add(row + col);
                    board[row, col] = true;

                    PutQueens(board, row + 1);

                    // Post recursive behaviour 
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonal.Remove(row - col);
                    attacktedRightDiagonal.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) 
                && !attackedCols.Contains(col)
                && !attackedLeftDiagonal.Contains(row - col)
                && !attacktedRightDiagonal.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == true)
                    {
                        Console.Write("* ");
                    }
                    else 
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}