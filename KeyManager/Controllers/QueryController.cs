using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers
{
    public class QueryController(DbContextOptions<AppDbContext> options)
    {
        private AppDbContext context = new(options);


        public List<Models.User> RetriveAll()
        {
            return [.. context.Users];
        }

        public bool AddDummy()
        {
            var newUser = new User { FirstName = "John", LastName = "Doe", SSN = 123456789 };
            context.Users.Add(newUser);
            context.SaveChanges();
            return true;
        }

        public bool AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
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

        public bool DeleteUser(int id)
        {
            User user = new User() { Id = id };
            context.Users.Attach(user);
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }

        public bool UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches and returns user based on SSN.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns>User object</returns>
        public User Search(String ssn)
        {
            var user = context.Users.Find(ssn);

            if (user is null)
            {
                throw new KeyNotFoundException($"User with SSN {ssn} not found.");
            }
            return user;
        }
    }
}
