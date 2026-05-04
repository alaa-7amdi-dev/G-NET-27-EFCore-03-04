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
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);
            builder.HasOne<Manager>(m => m.Manager)
                .WithOne(b => b.Branch)
                .HasForeignKey<Branch>(b => b.ManagerId);


            builder.HasMany<Account>(b => b.Accounts)
                .WithOne(a => a.Branch)
                .HasForeignKey(a => a.BranchCode);

            builder.HasData
                (
                  new Branch
                  {
                      Code = 101,
                      Name = "Alex",
                      Address = "ElMamora",
                      Phone = "0223456789",
                      ManagerId = 1
                  },
                new Branch
                {
                    Code = 102,
                    Name = "Cairo",
                    Address = "ElThrier",
                    Phone = "0345678901",
                    ManagerId = 2
                }


                );
        }
    }
}
