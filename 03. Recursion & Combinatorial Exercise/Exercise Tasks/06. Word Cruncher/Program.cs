namespace _06._Word_Cruncher
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static string targetWord;
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> result;

        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");

            targetWord = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            result = new LinkedList<string>();

            foreach (var word in words)
            {
                var index = targetWord.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                    continue;
                }

                wordsCount[word] = 1;

                // Searches if word can be used again in target on different index
                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex[index] = new List<string>();
                    }
                    wordsByIndex[index].Add(word);

                    index = targetWord.IndexOf(word, index + 1);
                }
            }

            GenSolution(0);
        }

        private static void GenSolution(int index)
        {
            if (index == targetWord.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            if (!wordsByIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsByIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                result.AddLast(word);

                GenSolution(index + word.Length);

                wordsCount[word] += 1;
                result.RemoveLast();
            }
        }
    }
}
