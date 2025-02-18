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

        public bool AddUser()
        {
            var newUser = new User { FirstName = "John", LastName = "Doe", SSN = 123456789 };
            context.Users.Add(newUser);
            context.SaveChanges();
            return true;
        }

        public Models.User Search(String ssn)
        {
            var user = context.Users.Find(1);
            return user;
        }

      
    }
}
