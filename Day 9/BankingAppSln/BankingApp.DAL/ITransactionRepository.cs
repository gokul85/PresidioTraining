using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Models;

namespace BankingApp.DAL
{
    public interface ITransactionRepository
    {
        Transaction AddTransaction(Transaction transaction);
    }
}
