using KeyManager.Data;
using KeyManager.ExceptionHandler;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers.QueryHandlers
{
    public class KeyQueryController(DbContextOptions<AppDbContext> options) : IQueryController<Key>
    {
        private AppDbContext context = new(options);

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
            // Check if key is used in any address
            if (context.Addresses.Any(a => a.Key.Id == id))
            {
                throw new KeyInUseException($"Key with ID {id} is in use.");
            }
            Address adresses = new() { Id = id };
            context.Addresses.Attach(adresses);
            context.Addresses.Remove(adresses);
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

            if (!keys.Any())
            {
                throw new KeyNotFoundException($"Key was not found.");
            }
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
            Key key = context.Keys.Find(id);

            if (key is null)
            {
                throw new KeyNotFoundException($"Key with ID {id} not found.");
            }
            return key;
        }

        public bool Update(int id, Key obj)
        {
            obj.Id = id;
            var key = context.Users.Find(obj.Id);
            if (key is null)
            {
                throw new KeyNotFoundException($"Key with ID {obj.Id} not found.");
            }
            context.Users.Update(key);
            context.SaveChanges();
            return true;
        }
    }
}
