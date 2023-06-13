using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVC.Models;

namespace WebMVC.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();

            builder.HasData(
                new[]
                {
                    new Category{Id=1,CategoryName="Select Category"},
                     new Category{Id=2,CategoryName="Mobiles"},
                     new Category{Id=3,CategoryName="Computers"},
                     new Category{Id=4,CategoryName="Electric Machines"},
                });
        }
    }
}
