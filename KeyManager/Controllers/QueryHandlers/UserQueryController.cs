using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers.QueryHandlers
{
    public class UserQueryController(DbContextOptions<AppDbContext> options) : IQueryController<User>
    {
        private AppDbContext context = new(options);


        public List<User> RetriveAll()
        {
            return [.. context.Users];
        }

        public bool Delete(int id)
        {
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

        public bool Update(User obj)
        {
            context.Users.Update(obj);
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

        public User RetrieveById(int id)
        {
            var user = context.Users.Find(id);
            if (user is null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }
    }
}
