using System.Numerics;
using BankingApp.Models;
using BankingApp.DAL;

namespace BankingApp.BL
{
    public class BankingService
    {
        private readonly IUserRepository _userrepository;
        private readonly ITransactionRepository _transactionrepository;
        public BankingService()
        {
            _userrepository = new UserRepository();
            _transactionrepository = new TransactionRepository();
        }
        public bool CheckUser(string username)
        {
            User user = _userrepository.GetUser(username);
            if(user == null)
                return false;
            else
                return true;
        }
        public void Register(string name, string username, string password, double startingBalance)
        {
            if (_userrepository.GetUser(username) != null)
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }

            var newUser = new User
            {
                Id = _userrepository.GetUserCount() + 1,
                Name = name,
                Username = username,
                Password = password,
                Balance = startingBalance,
                Transactions = new List<Transaction>()
            };

            _userrepository.AddUser(newUser);
            Console.WriteLine("Registration successful.");
        }

        public User Login(string username, string password)
        {
            var user = _userrepository.GetUser(username);

            if (user == null || user.Password != password)
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            Console.WriteLine("Login successful.");
            return user;
        }

        public void Deposit(User user, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            user.Balance += amount;
            var transaction = new Transaction
            {
                Type = "Deposit",
                Amount = amount,
                Timestamp = DateTime.Now,
                Receiver = user.Username,
                CurrentBalance = user.Balance,
                Description = "Deposit"
            };
            user.Transactions.Add(transaction);
            _userrepository.UpdateUser(user);
            _transactionrepository.AddTransaction(transaction);
            Console.WriteLine($"Deposit of {amount} successful. Current balance: {user.Balance}");
        }

        public void Withdraw(User user, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            if (user.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            user.Balance -= amount;
            var transaction = new Transaction
            {
                Type = "Withdrawal",
                Amount = amount,
                Timestamp = DateTime.Now,
                CurrentBalance = user.Balance,
                Description = "Withdrawal"
            };
            user.Transactions.Add(transaction);
            _userrepository.UpdateUser(user);
            _transactionrepository.AddTransaction(transaction);
            Console.WriteLine($"Withdrawal of {amount} successful. Current balance: {user.Balance}");
        }

        public void Transfer(User sender, string receiveruname, double amount)
        {
            User receiver = _userrepository.GetUser(receiveruname);
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return;
            }

            if (sender.Balance < amount)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            sender.Balance -= amount;
            receiver.Balance += amount;

            var sentransaction = new Transaction
            {
                Type = "STransfer",
                Amount = amount,
                Timestamp = DateTime.Now,
                Sender = sender.Username,
                Receiver = receiver.Username,
                Description = $"Transfer to {receiver.Name}",
                CurrentBalance = sender.Balance,
            };

            var rectransaction = new Transaction
            {
                Type = "RTransfer",
                Amount = amount,
                Timestamp = DateTime.Now,
                Sender = sender.Username,
                Receiver = receiver.Username,
                Description = $"Transfer from {sender.Name}",
                CurrentBalance = receiver.Balance,
            };

            sender.Transactions.Add(sentransaction);
            receiver.Transactions.Add(rectransaction);
            _userrepository.UpdateUser(sender);
            _userrepository.UpdateUser(receiver);
            _transactionrepository.AddTransaction(sentransaction);
            _transactionrepository.AddTransaction(rectransaction);
            Console.WriteLine($"Transfer of {amount} to {receiver.Name} successful. Current balance: {sender.Balance}");
        }

        public void GetBalance(User user)
        {
            Console.WriteLine($"Your balance: {user.Balance}");
        }

        public void GetTransactionHistory(User user)
        {
            Console.WriteLine($"Transaction History of {user.Name}");
            Console.WriteLine($"{"Date Time".PadRight(19)}\t{"Description".PadRight(20)}\t{"Debit".PadLeft(10)}{"Credit".PadLeft(10)}\t{"Balance".PadLeft(10)}");
            foreach (var transaction in user.Transactions)
            {
                string formattedDescription = transaction.Description.PadRight(20);
                string formattedAmount = transaction.Amount.ToString().PadLeft(10);
                string formattedBalance = transaction.CurrentBalance.ToString().PadLeft(10);

                if (transaction.Type == "Deposit" || transaction.Type == "RTransfer")
                {
                    Console.WriteLine($"{transaction.Timestamp}\t{formattedDescription}\t\t{formattedAmount}\t{formattedBalance}");
                }
                else if (transaction.Type == "Withdrawal" || transaction.Type == "STransfer")
                {
                    Console.WriteLine($"{transaction.Timestamp}\t{formattedDescription}\t{formattedAmount}\t\t{formattedBalance}");
                }

            }
        }
    }
}
