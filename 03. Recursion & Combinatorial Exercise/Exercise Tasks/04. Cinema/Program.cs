namespace _04._Cinema
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;


        public static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();

            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            var cmd = Console.ReadLine();

            while (cmd != "generate")
            {
                var input = cmd.Split(" - ");
                var name = input[0];
                var position = int.Parse(input[1]) - 1;

                people[position] = name;
                locked[position] = true;

                nonStaticPeople.Remove(name);

                cmd = Console.ReadLine();
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                PrintPeople();
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }

        private static void PrintPeople()
        {
            int index = 0;

            for (int i = 0; i < people.Length; i++)
            {
                if (!locked[i])
                {
                    people[i] = nonStaticPeople[index++];
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}