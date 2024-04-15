namespace UnderstandingSeq
{
    public class Program
    {
        static void UnderstandingSwitch() 
        {
            Console.WriteLine("Enter a number");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 0:
                    Console.WriteLine("You have choosen " + n);
                    break;
                case 1:
                    Console.WriteLine("You have choosen " + n);
                    break;
                case 2:
                    Console.WriteLine("You have choosen " + n);
                    break;
                case 3:
                    Console.WriteLine("You have choosen " + n);
                    break;
                default:
                    Console.WriteLine("You have choosen " + n);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Hello, World!");
            program.UnderstandingSwitch();
        }
    }
}
