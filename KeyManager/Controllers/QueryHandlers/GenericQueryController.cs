using KeyManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KeyManager.Controllers.QueryHandlers
{
    public class GenericQueryController<T, TContext> where T : class where TContext : DbContext
    {
        protected readonly TContext context;

        public GenericQueryController(DbContextOptions<TContext> options)
        {
            context = (TContext)Activator.CreateInstance(typeof(TContext), options)!;
        }

        public T RetrieveById(int id)
        {
            T entity = context.Set<T>().Find(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");
            }
            return entity;
        }
    }
}