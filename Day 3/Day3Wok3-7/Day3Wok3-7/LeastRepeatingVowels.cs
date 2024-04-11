using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Wok3_7
{
    public class LeastRepeatingVowels
    {
        public static void Execute()
        {
            Console.WriteLine("Enter comma-separated words:");
            string input = Console.ReadLine();
            string[] words = input.Split(',');
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (isVowel(word))
                {
                    
                    if (!wordCounts.ContainsKey(word))
                    {
                        int vowelCount = CountVowels(word, words);
                        wordCounts[word] = vowelCount;
                    }
                }
            }
            int minVowelCount = wordCounts.Values.Min();
            var wordsWithMinVowels = wordCounts.Where(kv => kv.Value == minVowelCount).Select(kv => kv.Key);
            Console.WriteLine($"Word(s) with the least number of repeating vowels ({minVowelCount}):");
            foreach (var word in wordsWithMinVowels)
            {
                Console.WriteLine($"{word}");
            }
        }
        static bool isVowel(string word)
        {
            string vowels = "aeiouAEIOU";
            return vowels.Contains(word);
        }
        static int CountVowels(string word, string[] words)
        {
            int count = 0;
            foreach (string c in words)
            {
                if (word == c)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
