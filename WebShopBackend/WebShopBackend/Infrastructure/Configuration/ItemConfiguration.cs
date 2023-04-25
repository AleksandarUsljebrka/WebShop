using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.Model;

namespace WebShopBackend.Infrastructure.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.ItemName).HasMaxLength(20);

            builder.HasOne(x => x.Salesman)
                   .WithMany(x => x.Items)
                   .HasForeignKey(x => x.SalesmanId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
