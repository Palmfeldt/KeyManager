using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers.QueryHandlers
{
    public class KeyQueryController(DbContextOptions<AppDbContext> options) : IQueryController<Key>
    {
        private AppDbContext context = new(options);


        public List<Key> RetriveAll()
        {
            return [.. context.Keys];
        }

        public Key RetrieveById(int id)
        {
            Key key = context.Keys.Find(id);
            if (key is not null)
            {
                return key;
            }
            throw new KeyNotFoundException($"Key with ID {id} not found.");
        }

        List<Key> IQueryController<Key>.RetriveAll()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
