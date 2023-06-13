using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVC.Models;

namespace WebMVC.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>

    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasData(new[]
            {
                new Item() { Id=1, Name="Item1",Price=150m ,CategoryId=2}
            });
        }
    }
}
