using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.Persistence.Data;
using KeyManager.Persistence.ExceptionHandler;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Persistence.Repositories;

public class KeyRepository(DbContextOptions<AppDbContext> options) : IRepository<Key>
{
    private readonly AppDbContext context = new(options);

    public Key RetrieveById(int id)
    {
        Key key = context.Keys.Find(id);
        if (key is not null)
        {
            return key;
        }
        throw new KeyNotFoundException($"Key with ID {id} not found.");
    }

    public List<Key> RetriveAll()
    {
        return [.. context.Keys];
    }

    public bool Delete(int id)
    {



        Key key = context.Keys.Find(id);

        if (key is null)
            return false;

        // Check if key is used in any property
        if (key.Property is not null)
            throw new KeyInUseException($"Key with ID {id} is in use.");

        context.Keys.Attach(key);
        context.Keys.Remove(key);
        context.SaveChanges();
        return true;
    }

    public bool Add(Key key)
    {
        context.Keys.Add(key);
        context.SaveChanges();
        return true;
    }

    public List<Key> Search(string input)
    {
        var keys = context.Keys.Where(u => u.KeyIdentifier == input).ToList();

        if (keys.Count == 0)
            throw new KeyNotFoundException($"Key was not found.");

        return keys;

    }

    /// <summary>
    /// Search with id
    /// </summary>
    /// <param name="id">Table id</param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public Key Search(int id)
    {
        Key key = context.Keys.Find(id)!;

        return key is null ? throw new KeyNotFoundException($"Key with ID {id} not found.") : key;
    }

    public bool Update(int id, Key obj)
    {
        obj.Id = id;
        var key = context.Residents.Find(obj.Id) ?? throw new KeyNotFoundException($"Key with ID {obj.Id} not found.");
        context.Residents.Update(key);
        context.SaveChanges();
        return true;
    }
}
