namespace Day3Wok3_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n;
                Console.WriteLine("Welcome to Day 3 of Gokul's Work \n What you would like to try \n 1 - Find Average all the numbers which are divisible by 7 \n 2 - Find the Length of the Given Word \n 3 - Login Demo Process with 3 Attemps \n 4 - Least repeating Vowels \n Please choose any the option to continue or 0 to Exit");
                while(int.TryParse(Console.ReadLine(), out n) == false)
                {
                    Console.WriteLine("Please Enter a Valid Number or Enter 0 to Exit");
                }
                if (n == 0)
                    break;
                else if (n == 1)
                    Average.Execute();
                else if (n == 2)
                    FindLength.Execute();
                else if (n == 3)
                    LoginDemo.Execute();
                else if (n == 4)
                    LeastRepeatingVowels.Execute();
                else
                    continue;
            }
        }
    }
}
