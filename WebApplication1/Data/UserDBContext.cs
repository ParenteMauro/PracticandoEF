using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Data.Entities;
using WebApplication1.Controller;
using WebApplication1.Ingreso;
namespace WebApplication1.Data;

public class UserDBContext : DbContext
{
    public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }
    public virtual DbSet<User> users {  get; set; } 
    public virtual DbSet<Product> products { get; set; }
    
    public virtual DbSet<Favorites> favorites { get; set; }

     

    public async Task<User> Get(int id)
    {
        return await users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> Post(UserDto newUser)

    {
        if(newUser != null) 
        { 
        User userInsert  = convertirUser(newUser);
        var response = await users.AddAsync(userInsert);
        await SaveChangesAsync();
            return response.Entity;
        }
        else
        {
            throw new Exception("No se pudo ingresar usuario");
        }      
    }

    public User convertirUser(UserDto newUser)
    {
        User user = new User()
        {
            Name = newUser.Name,
            SurName = newUser.SurName,
            EmailAddress = newUser.EmailAddress,
            Phone = newUser.Phone
        };
        return user;
    }
}
