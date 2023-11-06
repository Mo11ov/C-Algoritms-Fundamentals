namespace RecursionAndBacktracking
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintFugure(n);
        }

        private static void PrintFugure( int n)
        {
            if (n <= 0)
            {
                return;
            }

            // Pre recursive behavior
            Console.WriteLine(new string('*', n));

            PrintFugure(n - 1);

            // Post recursive behavior
            Console.WriteLine(new string('#', n));
        }
    }
}