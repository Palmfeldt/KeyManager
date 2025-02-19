using System.Net;
using KeyManager.Data;
using KeyManager.Models;
using KeyManager.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KeyManager.Controllers.QueryHandlers
{
    public class AddressQueryController(DbContextOptions<AppDbContext> options) : IQueryController<Address>
    {
        private AppDbContext context = new(options);


        public List<Address> RetriveAll()
        {
            return [.. context.Addresses];
        }

        public bool Delete(int id)
        {
            Address adresses = new() { Id = id };
            context.Addresses.Attach(adresses);
            context.Addresses.Remove(adresses);
            context.SaveChanges();
            return true;
        }

        public bool Add(Address obj)
        {
            ObjectValidator validator = new();

            // Check if id of user is not equal to 0
            if (!validator.CheckId(obj.User))
            {
                obj.User = context.Users.Find(obj.User.Id);
            }

            if (!validator.CheckId(obj.Key))
            {
                obj.Key = context.Keys.Find(obj.Key.Id);
            }

            context.Addresses.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(int id, Address obj)
        {
            throw new NotImplementedException();
        }

        // May be to specific
        public List<Address> Search(String address)
        {
            var fetchedAddress = context.Addresses.Where(u => u.FullAddress == address).ToList();

            if (!fetchedAddress.Any())
            {
                throw new KeyNotFoundException($"Address {address} not found.");
            }
            return fetchedAddress;
        }

        public Address RetrieveById(int id)
        {
            var address = context.Addresses.Find(id);
            if (address is null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }
            return address;
        }

   
    }
}
