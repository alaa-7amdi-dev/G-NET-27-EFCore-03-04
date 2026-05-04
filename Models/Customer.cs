using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string  CustomerType { get; set; }
        public int NationalId { get; set; }

        public Collection<CustomerAccount> CustomerAccounts { get; set; }

       
    }
}
