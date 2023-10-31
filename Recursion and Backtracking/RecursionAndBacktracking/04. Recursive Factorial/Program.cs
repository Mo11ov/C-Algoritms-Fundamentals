namespace RecursionAndBacktracking
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactorial(n));
        }

        private static int CalcFactorial(int n)
        {
            if (n == 0) 
            {
                return 1;
            }

            return n * CalcFactorial(n - 1);
        }
    }
}