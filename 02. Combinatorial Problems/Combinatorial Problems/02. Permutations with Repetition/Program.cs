namespace _02._Permutations_with_Repetition
{
    using System;
    using System.Collections.Generic;

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

            var used = new HashSet<string>() { permutations[index] };

            for (int i = index + 1; i < permutations.Length; i++)
            {
                if (!used.Contains(permutations[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                    used.Add(permutations[i]);
                }
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