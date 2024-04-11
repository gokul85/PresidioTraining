namespace Day3Work2GreatestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greatestNumber = int.MinValue;
            Console.WriteLine("Enter numbers (a negative number to stop):");
            while (true)
            {
                int number;
                while(int.TryParse(Console.ReadLine(), out number) == false)
                {
                    Console.WriteLine("Please Enter a valid number or negative number to exit");
                }
                if (number < 0)
                {
                    break;
                }
                if (number > greatestNumber)
                {
                    greatestNumber = number;
                }
            }
            Console.WriteLine("The greatest number entered is: " + greatestNumber);
        }
    }
}
