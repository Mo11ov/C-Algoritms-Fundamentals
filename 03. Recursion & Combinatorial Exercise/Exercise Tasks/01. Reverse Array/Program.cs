namespace _01._Reverse_Array
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split();

            ReverseArrayRecursivly(array, 0);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void ReverseArrayRecursivly(string[] arr, int index)
        {
            if (index == arr.Length / 2)
            {
                return;
            }

            var temp = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;

            ReverseArrayRecursivly(arr, index + 1);
        }
    }
}