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
    internal class CustomerAccountConfig : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasOne<Account>(a => a.Accounts)
                .WithMany(ca => ca.Customers)
                .HasConstraintName("FK_CustomerAccount_Account")
                .HasForeignKey(ca => ca.AccountNumber);

            builder.HasOne<Customer>(c => c.Customers)
                .WithMany(ca => ca.CustomerAccounts)
                .HasConstraintName("FK_CustomerAccount_Customer")
                .HasForeignKey(ca => ca.CustomerId);
        }
    }
}
