using Bank_management__System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management__System.Configrutions
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);

            builder.HasMany<Transaction>(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId);


            //DataSeeding

            builder.HasData
                (
                  new Account
                  {
                      AccountNumber = 1000001,
                      CurrentBalance = 50000.75m,
                      AccountType = "Saving",
                      OpeingDate = DateTime.Now.AddMonths(-6),
                      BranchCode = 101
                  },
                new Account
                {
                    AccountNumber = 1000002,
                    CurrentBalance = 125000.00m,
                    AccountType = "Current",
                    OpeingDate = DateTime.Now.AddMonths(-3),
                    BranchCode = 101
                },
                new Account
                {
                    AccountNumber = 1000003,
                    CurrentBalance = 7500.50m,
                    AccountType = "Saving",
                    OpeingDate = DateTime.Now.AddMonths(-1),
                    BranchCode = 102
                }

                );
        }
    }
}
