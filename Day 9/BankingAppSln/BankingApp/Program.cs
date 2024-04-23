using BankingApp.Models;
using BankingApp.DAL;
using BankingApp.BL;
namespace BankingApp
{
    public class Program
    {
        static BankingService bankingService;
        static User? currentUser = null;
        static void Register()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name Can't be Empty\nEnter Name:");
                name = Console.ReadLine();
            }
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(username) || bankingService.CheckUser(username))
            {
                Console.WriteLine("Invalid Username\nEnter Username:");
                username = Console.ReadLine();
            }
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            string password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            while (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password Can't be Empty\nEnter Password:");
                Console.ForegroundColor = ConsoleColor.Black;
                password = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.Write("Enter starting balance: ");
            double startingBalance;
            while (!double.TryParse(Console.ReadLine(), out startingBalance))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            bankingService.Register(name, username, password, startingBalance);
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string loginUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            string loginPassword = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            currentUser = bankingService.Login(loginUsername, loginPassword);
        }
        static void UserDeposit()
        {
            Console.Write("Enter amount to deposit: ");
            double depositAmount;
            if (!double.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            bankingService.Deposit(currentUser, depositAmount);
        }
        static void UserWithdraw()
        {
            Console.Write("Enter amount to withdraw: ");
            double withdrawAmount;
            if (!double.TryParse(Console.ReadLine(), out withdrawAmount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            bankingService.Withdraw(currentUser, withdrawAmount);
        }
        static void UserTransfer()
        {
            Console.Write("Enter receiver's username: ");
            string receiverUsername = Console.ReadLine();
            if (!bankingService.CheckUser(receiverUsername))
            {
                Console.WriteLine("Receiver not found.");
                return;
            }
            Console.Write("Enter amount to transfer: ");
            double transferAmount;
            if (!double.TryParse(Console.ReadLine(), out transferAmount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            bankingService.Transfer(currentUser, receiverUsername, transferAmount);
        }
        static void Main(string[] args)
        {
            bankingService = new BankingService();
            Console.WriteLine("Welcome to Console Banking App");
            while (true)
            {
                if (currentUser == null)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }
                    switch (choice)
                    {
                        case 1:
                            Register();
                            break;
                        case 2:
                            Login();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Welcome, {currentUser.Name}!");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Transfer");
                    Console.WriteLine("4. Check Balance");
                    Console.WriteLine("5. Show Transaction History");
                    Console.WriteLine("6. Logout");
                    Console.Write("Enter your choice: ");
                    int operationChoice;
                    if (!int.TryParse(Console.ReadLine(), out operationChoice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }
                    switch (operationChoice)
                    {
                        case 1:
                            UserDeposit();
                            break;
                        case 2:
                            UserWithdraw();
                            break;
                        case 3:
                            UserTransfer();
                            break;
                        case 4:
                            bankingService.GetBalance(currentUser);
                            break;
                        case 5:
                            bankingService.GetTransactionHistory(currentUser);
                            break;
                        case 6:
                            currentUser = null;
                            Console.WriteLine("Logged out.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}
