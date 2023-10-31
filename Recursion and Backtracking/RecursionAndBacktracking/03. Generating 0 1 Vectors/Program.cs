namespace RecursionAndBacktracking
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Gen01(array, 0);
        }

        private static void Gen01(int[] arr, int index)
        {
            if (index >= arr.Length) 
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                Gen01(arr, index + 1);
            }
        }
    }
}