using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    public class Transaction
    {
        public int TransactinNumber { get; set; }
        public string TransactionType { get; set; }
        public string? Note { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
