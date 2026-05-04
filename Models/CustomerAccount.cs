using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    [PrimaryKey(nameof(AccountNumber), nameof(CustomerId))]
    public class CustomerAccount
    {
        
        public string AccountStatus { get; set; }
        public string OwnerShipType { get; set; }
        public DateOnly OwnerShipStartDate { get; set; }
        public Account Accounts { get; set; }
        public int AccountNumber { get; set; }

        public Customer Customers { get; set; }
        public int CustomerId { get; set; }
    }
}
