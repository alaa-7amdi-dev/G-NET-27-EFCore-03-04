using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public string AccountType { get; set; }
        public DateTime OpeingDate { get; set; }
        public Branch Branch { get; set; }
        public int BranchCode { get; set; }
        public Collection<Transaction> Transactions { get; set; }
        public Collection<CustomerAccount> Customers { get; set; }


    }
}
