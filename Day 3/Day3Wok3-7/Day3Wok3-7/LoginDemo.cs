using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Wok3_7
{
    public class LoginDemo
    {
        public static void Execute()
        {
            string correctUsername = "ABC";
            string correctPassword = "123";
            int maxAttempts = 3;
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                Console.WriteLine("Enter Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();
                if (username == correctUsername && password == correctPassword)
                {
                    Console.WriteLine("Login successful");
                    return;
                }
                else
                {
                    attempts++;
                    int remainingAttempts = maxAttempts - attempts;
                    Console.WriteLine($"Login failed. You have {remainingAttempts} attempts remaining.");
                }
            }
            Console.WriteLine("You've exceeded the maximum number of attempts. Login failed.");
        }
    }
}
