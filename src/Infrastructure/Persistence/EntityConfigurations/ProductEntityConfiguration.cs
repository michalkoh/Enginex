using Enginex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enginex.Infrastructure.Persistence.EntityConfigurations
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(
                p => p.Name,
                n =>
                {
                    n.Property(p => p.Slovak)
                        .HasColumnName("Name_sk")
                        .IsRequired()
                        .HasMaxLength(200);
                    n.Property(p => p.English)
                        .HasColumnName("Name_en")
                        .IsRequired()
                        .HasMaxLength(200);
                });

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasMaxLength(30);

            builder.OwnsOne(
                p => p.Description,
                n =>
                {
                    n.Property(p => p.Slovak)
                        .HasColumnName("Description_sk")
                        .HasMaxLength(2000);
                    n.Property(p => p.English)
                        .HasColumnName("Description_en")
                        .HasMaxLength(2000);
                });

            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnName("Image")
                .HasMaxLength(100);
        }
    }
}
