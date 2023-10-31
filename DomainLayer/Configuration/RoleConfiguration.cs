using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id)
                .Metadata
                .IsPrimaryKey();

            builder.Property(x => x.Id)
                     .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired();


        }
    }
}
