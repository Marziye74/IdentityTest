using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id)
                .Metadata
                .IsPrimaryKey();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .IsRequired()
                .Metadata
                .IsUniqueIndex();

            builder.Property(x => x.Email)
                .IsRequired()
                .Metadata
                .IsUniqueIndex();

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .Metadata
                .IsUniqueIndex();
        }
    }
}
