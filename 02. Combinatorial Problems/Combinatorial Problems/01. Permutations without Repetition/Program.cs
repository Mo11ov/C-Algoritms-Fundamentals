namespace _01._Permutations_without_Repetition
{
    using System;

    public class Program
    {
        private static string[] permutations;

        public static void Main(string[] args)
        {
            permutations = Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < permutations.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }

        }

        public static void Swap(int firstIndex, int secondIndex)
        {
            var temp = permutations[firstIndex];
            permutations[firstIndex] = permutations[secondIndex];
            permutations[secondIndex] = temp;
        }
    }
}