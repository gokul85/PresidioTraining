using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Wok3_7
{
    public class FindLength
    {
        public static void Execute()
        {
            Console.WriteLine("Enter a word:");
            string word = Console.ReadLine();
            int length = word.Length;
            Console.WriteLine($"The length of the word \"{word}\" is: {length}");
        }
    }
}
