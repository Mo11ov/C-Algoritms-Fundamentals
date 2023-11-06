namespace RecursionAndBacktracking
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] inputArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.WriteLine(GetSum(inputArr, 0));
        }

        private static int GetSum(int[] arr, int index) 
        {
            if (index >= arr.Length)
            { 
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}