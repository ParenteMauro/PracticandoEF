using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Entities;
namespace WebApplication1.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product() { Id = 1, Description = "asdasdasd", Price = 10, Name = "product1" },
            new Product() { Id = 3, Description = "asdasdasd", Price = 10, Name = "product3" },
            new Product() { Id = 2, Description = "asdasdasd", Price = 10, Name = "product2" }
            );
        }
    }
}
