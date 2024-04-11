namespace FirstConsoleApp
{
    internal class Program
    {
       static int TakeNumber()
        {
            Console.WriteLine("Please enter a number");
            //int n = Convert.ToInt32(Console.ReadLine());
            int n = int.Parse(Console.ReadLine()??"0");
            return n;
        }
        static int Add(int n1, int n2)
        {
            return n1 + n2;
        }
        static void PrintResult(int val,string ops)
        {
            Console.WriteLine($"The {ops} is {val}");
        }
        static void Calculate()
        {
            int num1, num2;
            num1 = TakeNumber();
            num2 = TakeNumber();
            int sum = Add(num1, num2);
            PrintResult(sum, "Sum");
        }
        static void Main(string[] args)
        {
            Calculate();
        }
    }
}
