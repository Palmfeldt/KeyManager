
namespace KeyManager.Controllers.QueryHandlers
{
    public interface IQueryController<T>
    {
        public List<T> RetriveAll();

        public bool Delete(int id);

        public bool Add(T obj);

        public bool Update(int id, T obj);

        // Search Strict
        public T RetrieveById(int id);

    }
}
