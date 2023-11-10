namespace _02._Nested_Loops
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            SimulateLoops(array, 0);
        }

        private static void SimulateLoops(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                SimulateLoops(arr, index + 1);
            }
        }
    }
}