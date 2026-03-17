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
        return [.. context.Residents];
    }

    public Resident RetrieveById(int id)
    {
        var user = context.Residents.Find(id);
        return user is null ? throw new KeyNotFoundException($"User with ID {id} not found.") : user;
    }

    public bool Delete(int id)
    {
        var resident = context.Residents.Find(id);
        if (resident is null)
            return false;

        context.Residents.Attach(resident);
        context.Residents.Remove(resident);
        context.SaveChanges();
        return true;
    }

    public bool Add(Resident obj)
    {
        context.Residents.Add(obj);
        context.SaveChanges();
        return true;
    }

    public bool Update(int id, Resident obj)
    {
        obj.Id = id;
        var user = context.Residents.Find(obj.Id) ?? throw new KeyNotFoundException($"User with ID {obj.Id} not found.");
        context.Residents.Update(user);
        context.SaveChanges();
        return true;
    }

    public List<Resident> Search(long pnum)
    {
        var users = context.Residents.Where(u => u.Pnum == pnum).ToList();

        if (users.Count == 0)
            throw new KeyNotFoundException($"User with Pnum {pnum} not found.");

        return users;
    }
}
