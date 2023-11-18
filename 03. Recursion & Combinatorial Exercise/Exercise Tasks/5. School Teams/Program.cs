
namespace _5._School_Teams
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsComb = new string[3];
            var allGirlComb = new List<string>();

            GenerateComb(0, 0, girls, girlsComb, allGirlComb);

            var boys = Console.ReadLine().Split(", ");
            var allBoysComb = new List<string>();
            var boysComb = new string[2];

            GenerateComb(0, 0, boys, boysComb, allBoysComb);

            foreach (var girlComb in allGirlComb)
            {
                foreach (var boyComb in allBoysComb)
                {
                    Console.WriteLine($"{girlComb}, {boyComb}");
                }
            }
        }

        private static void GenerateComb(
            int index,
            int elementStartIndex,
            string[] elements,
            string[] comb,
            List<string> allCombs)
        {
            if (index >= comb.Length)
            {
                allCombs.Add(string.Join(", ", comb));
                return;
            }

            for (int i = elementStartIndex; i < elements.Length; i++)
            {
                comb[index] = elements[i];
                GenerateComb(index + 1, i + 1, elements, comb, allCombs);
            }
        }
    }
}
