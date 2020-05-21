using Enginex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enginex.Infrastructure.Persistence.EntityConfigurations
{
    internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(
                c => c.Name,
                n =>
                {
                    n.Property(p => p.Slovak)
                        .HasColumnName("Name_sk")
                        .IsRequired()
                        .HasMaxLength(40);
                    n.Property(p => p.English)
                        .HasColumnName("Name_en")
                        .IsRequired()
                        .HasMaxLength(40);
                });

            builder.Property(c => c.Order)
                .IsRequired()
                .HasColumnName("Order");
        }
    }
}
