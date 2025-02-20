using System.Net;
using KeyManager.Data;
using KeyManager.Models;
using KeyManager.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KeyManager.Repositories
{
    public class AddressQueryController(DbContextOptions<AppDbContext> options) : IQueryController<Address>
    {
        private AppDbContext context = new(options);
        public Address RetrieveById(int id)
        {
            var address = context.Addresses.Find(id);
            context.Entry(address).Reference(x => x.User).Load();
            context.Entry(address).Reference(x => x.Key).Load();

            if (address is null)
            {
                throw new KeyNotFoundException($"Address with ID {id} not found.");
            }
            return address;
        }

        public List<Address> RetriveAll()
        {
            return context.Addresses.Include(x => x.Key)
                .Include(x => x.User).ToList();
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
            context.Addresses.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(int id, Address obj)
        {
            obj.Id = id;
            var address = context.Addresses.Find(obj.Id);
            if (address is null)
            {
                throw new KeyNotFoundException($"Address with ID {obj.Id} not found.");
            }
            context.Addresses.Update(address);
            context.SaveChanges();
            return true;
        }

        // May be to specific
        public List<Address> Search(string address)
        {
            var fetchedAddress = context.Addresses.Where(u => u.FullAddress == address).ToList();

            if (!fetchedAddress.Any())
            {
                throw new KeyNotFoundException($"Address {address} not found.");
            }
            return fetchedAddress;
        }


    }
}
