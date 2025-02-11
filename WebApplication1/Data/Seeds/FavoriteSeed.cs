using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Entities;
namespace WebApplication1.Data.Seeds
{
    public class FavoriteSeed : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasData
                (
                new Favorite()
                {
                    Id = 1,
                    product_Id = 1,
                    UserId = 10
                },
                new Favorite()
                {
                    Id = 2,
                    product_Id = 2,
                    UserId = 10
                }
                );
        }
    }
}
