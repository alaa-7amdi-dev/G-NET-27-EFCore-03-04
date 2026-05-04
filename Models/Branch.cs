using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Models
{
    public class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Phone { get; set; }
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }
        public Collection<Account> Accounts { get; set; }
    }
}
