using Bank_management__System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bank_management__System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("=================================");
            Console.WriteLine("National Bank  _ Management");
            Console.WriteLine("=================================");



            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        AddNewCustomer();
                        break;
                    case "2":
                        OpenNewAccount();
                        break;
                    case "3":
                        UpdateAccountStatus();
                        break;
                    case "4":
                        //RemoveAccountFromCustomer();
                        break;
                    case "5":
                        //ListAllCustomers();
                        break;
                    case "0":
                        Console.WriteLine("Exist");
                        return;
                    default:
                        Console.WriteLine("Try Again");
                        break;

                }
                Console.WriteLine("Press any Key To Return to The Menu");
                Console.ReadKey();
             
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("National Bank  _ Management");
            Console.WriteLine("=================================");
            Console.WriteLine("1) Add Branch");
            Console.WriteLine("2) Add Manager");
            Console.WriteLine("3) Add Account");
            Console.WriteLine("4) Display Branches");
            Console.WriteLine("5) Display Managers");
            Console.WriteLine("6) Display Accounts");
            Console.WriteLine("7) Exit");
        }

        static void AddNewCustomer()
        {
             
            
                Console.Clear();
                Console.WriteLine("----Add New Customer----");
                Console.Write("Full Name: ");
                string fullName = Console.ReadLine()!;

                Console.Write("National ID: ");
                int nationalId = int.Parse(Console.ReadLine());

                Console.Write("Date of Birth (yyyy-MM-dd): ");
                DateOnly dob = DateOnly.Parse(Console.ReadLine()!);

                Console.Write("Email: ");
                string email = Console.ReadLine()!;

                Console.Write("Phone: ");
                string phone = Console.ReadLine()!;

                Console.Write("Address: ");
                string address = Console.ReadLine()!;
                Console.WriteLine("Customer Type:");
                Console.WriteLine("1) Individual");
                Console.WriteLine("2) Business");
                Console.Write("Choice: ");
                string typeChoice = Console.ReadLine()!;
                string customerType = typeChoice == "2" ? "Business" : "Individual";
                var Customer = new Customer()
                {
                    FullName = fullName,
                    NationalId = nationalId,
                    DateOfBirth = dob,
                    Email = email,
                    Address = address,
                    CustomerType = customerType
                };

           using Data.AppDbContext db = new Data.AppDbContext();
            db.Add(Customer);
            db.SaveChanges();
              Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Customer added successfully!");
             Console.ResetColor();
        }
        static void OpenNewAccount()
        {
            using Data.AppDbContext db = new Data.AppDbContext();
            Console.Clear();
            Console.WriteLine("--- Open New Account ---");

            Console.Write("Account Number: ");
            int accountNumber = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Account Type:");
            Console.WriteLine("1) Savings");
            Console.WriteLine("2) Current");
            Console.WriteLine("3) Business");
            Console.Write("Choice: ");
            string accTypeChoice = Console.ReadLine()!;
            string accountType = accTypeChoice switch
            {
                "1" => "Savings",
                "2" => "Current",
                "3" => "Business",
                _ => "Savings"
            };

            Console.Write("Branch Code: ");
            int branchCode = int.Parse(Console.ReadLine()!);

            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine()!);

            var branch = db.Branches.Find(branchCode);
            var customer = db.Customers.Find(customerId);

            if (branch == null || customer == null)
            {
                Console.WriteLine(" Branch or Customer not found!");
                return;
            }

            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                BranchCode = branchCode,
                CurrentBalance = 0
            };

            db.Accounts.Add(account);
            db.SaveChanges();

            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                
            };

            db.Add(customerAccount);
            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Account '{accountNumber}' created and linked to customer {customerId} as .");
            Console.ResetColor();
        }
        static void UpdateAccountStatus()
        {
            using Data.AppDbContext _context = new Data.AppDbContext();
            Console.Clear();
            Console.WriteLine("--- Update Account Status ---");

            Console.Write("Account Number: ");
            int accNum = int.Parse(Console.ReadLine()!);

            Console.Write("Customer Id: ");
            int custId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("New Status:");
            Console.WriteLine("1) Active");
            Console.WriteLine("2) Closed");
            Console.Write("Choice: ");
            string statusChoice = Console.ReadLine()!;

            var ca = _context.Set<CustomerAccount>()
                .FirstOrDefault(c => c.AccountNumber == accNum && c.CustomerId == custId);

            if (ca == null)
            {
                Console.WriteLine("Ownership link not found!");
                return;
            }

            ca.AccountStatus = statusChoice == "2" ? "Closed ":"Active";
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Status updated to {(ca.AccountStatus == "Active" ? "Active" : "Closed")}.");
            Console.ResetColor();
        }
    }
}
