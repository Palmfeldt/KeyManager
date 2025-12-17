using KeyManager.Application;
using KeyManager.ExceptionHandler;
using KeyManager.Persistence.Data;
using KeyManager.Persistence.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Repositories;

public class UserRepository(DbContextOptions<AppDbContext> options) : IRepository<User>
{
    private readonly AppDbContext context = new(options);

    public List<User> RetriveAll()
    {
        return [.. context.Users];
    }

    public User RetrieveById(int id)
    {
        var user = context.Users.Find(id);
        return user is null ? throw new KeyNotFoundException($"User with ID {id} not found.") : user;
    }

    public bool Delete(int id)
    {
        if (context.Addresses.Any(a => a.User.Id == id))
        {
            throw new KeyInUseException($"Key with ID {id} is in use.");
        }
        User user = new() { Id = id, FirstName = "Test", LastName = "Testsson" };
        context.Users.Attach(user);
        context.Users.Remove(user);
        context.SaveChanges();
        return true;
    }

    public bool Add(User obj)
    {
        context.Users.Add(obj);
        context.SaveChanges();
        return true;
    }

    public bool Update(int id, User obj)
    {
        obj.Id = id;
        var user = context.Users.Find(obj.Id) ?? throw new KeyNotFoundException($"User with ID {obj.Id} not found.");
        context.Users.Update(user);
        context.SaveChanges();
        return true;
    }

    public List<User> Search(long ssn)
    {
        var users = context.Users.Where(u => u.Pnum == ssn).ToList();

        if (users.Count == 0)
            throw new KeyNotFoundException($"User with SSN {ssn} not found.");

        return users;
    }

}
