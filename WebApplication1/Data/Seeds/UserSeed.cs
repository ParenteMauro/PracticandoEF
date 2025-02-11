using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Data.Entities;
namespace WebApplication1.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
                (
                  new User()
                  {
                      Id = 10,
                      EmailAddress = "user10@gmail.com",
                      Name = "user10",
                      Phone = "Phone",
                      SurName = "saddas",
                     
                  },
                  new User() { Id = 11, EmailAddress = "user11@gmail.com", Name = "user11", Phone = "Phone", SurName = "saddas" }
                );
        }

    }
}
