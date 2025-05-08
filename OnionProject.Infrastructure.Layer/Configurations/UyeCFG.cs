using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Infrastructure.Layer.Configurations
{
    public class UyeCFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            var uye = new Uye
            {
                Id = 1,
                UserName = "superUser",
                NormalizedUserName = "SUPERUSER",
                Email = "superuser@mail.com",
                NormalizedEmail = "SUPERUSER@MAİL.COM",
                Adres = "İstanbul Kadıköy",
                EmailConfirmed = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var hasher = new PasswordHasher<Uye>();
            uye.PasswordHash = hasher.HashPassword(uye, "spRuser_123");

            builder.HasData(uye);
        }
    }
}
