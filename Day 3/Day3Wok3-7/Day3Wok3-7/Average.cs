using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Wok3_7
{
    public class Average
    {
        public static void Execute()
        {
            int sum = 0;
            int count = 0;
            Console.WriteLine("Enter numbers (a negative number to stop):");
            while (true)
            {
                int number;
                while(int.TryParse(Console.ReadLine(), out number) == false)
                {
                    Console.WriteLine("Please Enter a valid number or Enter a negative number to exit");
                }
                if (number < 0)
                {
                    break;
                }
                if (number % 7 == 0)
                {
                    sum += number;
                    count++;
                }
            }
            if (count > 0)
            {
                double average = sum / count;
                Console.WriteLine($"The average of numbers divisible by 7 is: {average}");
            }
            else
            {
                Console.WriteLine("No numbers divisible by 7 were entered.");
            }
        }
    }
}
