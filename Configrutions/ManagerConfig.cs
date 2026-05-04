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
    public class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasData
                (
                  new Manager
                  {
                      Id = 1,
                      FullName = "Ahmed Hassan",
                      Email = "ahmed.hassan@bank.com",
                      PhoneNumber = "01012345678",
                      HireDate = new DateOnly(2023, 5, 15)
                  },
                new Manager
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara.mohamed@bank.com",
                    PhoneNumber = "01198765432",
                    HireDate = new DateOnly(2024, 1, 10)
                }
                );
            
        }
    }
}
