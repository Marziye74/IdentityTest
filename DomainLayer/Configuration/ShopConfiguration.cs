using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(sh => sh.Id)
                .Metadata
                .IsPrimaryKey();

            builder.Property(sh => sh.Id)
                .ValueGeneratedOnAdd();

            builder.Property(sh => sh.Name)
                .IsRequired();

            builder.HasOne(u => u.User).WithMany(sh => sh.shops).HasForeignKey(u => u.UserId);


        }
    }
}
