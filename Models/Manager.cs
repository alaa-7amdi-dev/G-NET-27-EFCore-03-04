using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string  Email { get; set; }
        public string  PhoneNumber { get; set; }
        public DateOnly HireDate { get; set; }
        public Branch Branch { get; set; }
    }
}
