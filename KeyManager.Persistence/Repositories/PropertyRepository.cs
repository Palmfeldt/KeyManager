using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Repositories;

public class PropertyRepository(DbContextOptions<AppDbContext> options) : IRepository<Property>
{
    private readonly AppDbContext context = new(options);
    public Property RetrieveById(int id)
    {
        var property = context.Properties.Find(id);
        context.Entry(property).Reference(x => x.Resident).Load();
        context.Entry(property).Collection(x => x.Keys).Load();
        if (property is null)
            throw new KeyNotFoundException($"Property with ID {id} not found.");

        return property;
    }

    public List<Property> RetriveAll()
    {
        return [.. context.Properties.Include(x => x.Keys).Include(x => x.Resident)];
    }

    public bool Delete(int id)
    {
        var property = RetrieveById(id);
        context.Properties.Attach(property);
        context.Properties.Remove(property);
        context.SaveChanges();
        return true;
    }

    public bool Add(Property obj)
    {
        context.Properties.Add(obj);
        context.SaveChanges();
        return true;
    }
    public bool Update(int id, Property obj)
    {
        obj.Id = id;
        var property = context.Properties.Find(obj.Id) ?? throw new KeyNotFoundException($"Property with ID {obj.Id} not found.");
        context.Properties.Update(property);
        context.SaveChanges();
        return true;
    }

    // May be to specific
    public List<Property> Search(string address)
    {
        var fetchedAddress = context.Properties.Where(u => u.Address == address).ToList();

        if (fetchedAddress.Count == 0)
            throw new KeyNotFoundException($"Address {address} not found.");

        return fetchedAddress;
    }
}
