using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.Persistence.Data;
using KeyManager.Persistence.ExceptionHandler;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Repositories;

public class ResidentRepository(DbContextOptions<AppDbContext> options) : IRepository<Resident>
{
    private readonly AppDbContext context = new(options);

    public List<Resident> RetriveAll()
    {
        return [.. context.Users];
    }

    public Resident RetrieveById(int id)
    {
        var user = context.Users.Find(id);
        return user is null ? throw new KeyNotFoundException($"User with ID {id} not found.") : user;
    }

    public bool Delete(int id)
    {
        if (context.Addresses.Any(a => a.User!.Id == id))
            throw new KeyInUseException($"Key with ID {id} is in use.");

        Resident user = new() { Id = id, FirstName = "Test", LastName = "Testsson" };
        context.Users.Attach(user);
        context.Users.Remove(user);
        context.SaveChanges();
        return true;
    }

    public bool Add(Resident obj)
    {
        context.Users.Add(obj);
        context.SaveChanges();
        return true;
    }

    public bool Update(int id, Resident obj)
    {
        obj.Id = id;
        var user = context.Users.Find(obj.Id) ?? throw new KeyNotFoundException($"User with ID {obj.Id} not found.");
        context.Users.Update(user);
        context.SaveChanges();
        return true;
    }

    public List<Resident> Search(long pnum)
    {
        var users = context.Users.Where(u => u.Pnum == pnum).ToList();

        if (users.Count == 0)
            throw new KeyNotFoundException($"User with Pnum {pnum} not found.");

        return users;
    }
}
