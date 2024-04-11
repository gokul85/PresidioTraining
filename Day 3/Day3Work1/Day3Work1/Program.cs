namespace Day3Work1
{
    internal class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subract(int a, int b)
        {
            return b - a;
        }
        static int Product(int a, int b)
        {
            return a * b;
        }

        static float Divide(int a, int b)
        {
            return a / b;
        }
        static int ReverseSub(int a, int b)
        {
            return a - b;
        }

        static int Reminder(int a, int b)
        {
            return (a % b);
        }
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("Please Enter the First Number");
            while(int.TryParse(Console.ReadLine(), out n1) == false)
            {
                Console.WriteLine("Please provide a valid number");
            }
            Console.WriteLine("Please Enter the Second Number");
            while (int.TryParse(Console.ReadLine(), out n2) == false)
            {
                Console.WriteLine("Please provide a valid number");
            }
            Console.WriteLine($"Sum of {n1} and {n2} is {Add(n1,n2)}");
            Console.WriteLine($"Subract of {n2} from {n1} is {Subract(n1,n2)}");
            Console.WriteLine($"Product of {n1} and {n2} is {Product(n1,n2)}");
            Console.WriteLine($"Divide of {n1} by {n2} is {Divide(n1,n2)}");
            Console.WriteLine($"Subract of {n1} from {n2} is {ReverseSub(n1,n2)}");
            Console.WriteLine($"Reminder when {n1} by {n2} is {Reminder(n1,n2)}");
        }
    }
}
