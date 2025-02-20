using KeyManager.Data;
using KeyManager.ExceptionHandler;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers.QueryHandlers
{
    public class UserQueryController(DbContextOptions<AppDbContext> options) : GenericQueryController<Key, AppDbContext>
    {
        private AppDbContext context = new(options);

        public KeyQueryController(DbContextOptions<AppDbContext> options) : base(options) { }

        public List<User> RetriveAll()
        {
            return [.. context.Users];
        }

        public User RetrieveById(int id)
        {
            var user = context.Users.Find(id);
            if (user is null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        public bool Delete(int id)
        {
            if (context.Addresses.Any(a => a.User.Id == id))
            {
                throw new KeyInUseException($"Key with ID {id} is in use.");
            }
            User user = new() { Id = id };
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
            var user = context.Users.Find(obj.Id);
            if (user is null)
            {
                throw new KeyNotFoundException($"User with ID {obj.Id} not found.");
            }
            context.Users.Update(user);
            context.SaveChanges();
            return true;
        }

        public List<User> Search(long ssn)
        {
            var users = context.Users.Where(u => u.SSN == ssn).ToList();

            if (!users.Any())
            {
                throw new KeyNotFoundException($"User with SSN {ssn} not found.");
            }
            return users;
        }

    }
}
