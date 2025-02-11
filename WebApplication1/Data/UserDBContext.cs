using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Data.Entities;
using WebApplication1.Controller;
using WebApplication1.Ingreso;
using WebApplication1.Data.Seeds;
namespace WebApplication1.Data;

public class UserDBContext : DbContext
{
    public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }
    public virtual DbSet<User> users { get; set; }
    public virtual DbSet<Product> products { get; set; }

    public virtual DbSet<Favorite> favorites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserSeed());
        modelBuilder.ApplyConfiguration(new ProductSeed());
    }

    public async Task<User> Get(int id)
    {
        return await users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User>> GetList()
    {
        return await users.ToListAsync();
    }

    public async Task<User> Post(UserDto newUser)

    {
        if (newUser != null)
        {
            User userInsert = convertirUser(newUser);
            var response = await users.AddAsync(userInsert);
            await SaveChangesAsync();
            return response.Entity;
        }
        else
        {
            throw new Exception("No se pudo ingresar usuario");
        }
    }

    public async Task<bool> Delete(int id)
    {
        User? user = await users.FirstOrDefaultAsync(u => u.Id == id);
        if (user != null)
        {
            users.Remove(user);
            await SaveChangesAsync();
            return true;
        }

        else
            return false;

    }

    public async Task<bool> Replace(User replaceUser)
    {
        var oldUser = await users.FirstOrDefaultAsync(user => user.Id == replaceUser.Id);

        if (oldUser != null)
        {
            if((oldUser.SurName != replaceUser.SurName) && (oldUser.Name != replaceUser.Name) && (oldUser.EmailAddress != replaceUser.EmailAddress) && (oldUser.Phone != replaceUser.Phone))
            users.Entry(oldUser).CurrentValues.SetValues(replaceUser);
            await SaveChangesAsync(); 
            return true;
        }
        return false;
    }
    public async Task<bool> Update(User userEdited)
    {
        var oldDataUser = await users.FirstOrDefaultAsync(user => user.Id == userEdited.Id);
        if ( oldDataUser != null)
        {
            users.Entry(oldDataUser).CurrentValues.SetValues(userEdited);
            await SaveChangesAsync();   

            return true;
        }
        else 
            return false;
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
