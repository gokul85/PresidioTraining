using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblem
{
    public class ExcelColumnTile
    {
        static string ConvertToTile(int n)
        {
            StringBuilder s = new StringBuilder();
            while(n > 0)
            {
                n--;
                int rem = n % 26;
                s.Append((char)('A' + rem));
                n /= 26;
            }
            return new string(s.ToString().Reverse().ToArray());
        }
        public static void FindTileLetter()
        {
            int n = 1;
            while(n != 0)
            {
                Console.WriteLine("Enter the number:");

                while (int.TryParse(Console.ReadLine(), out n) == false)
                {
                    Console.WriteLine("Please Enter a valid Number");
                }
                Console.WriteLine($"The Excel Tile for the number {n} is {ConvertToTile(n)}");
            }
            
        }
    }
}
