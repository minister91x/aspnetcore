namespace WebCoreAPI.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
    }
}
