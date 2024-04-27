namespace Cosmos.MongoDbAPI.Data.BusinessObjects.Base
{
    public interface IBaseCore<T> where T : class
    {
        Task Create(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(string id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Search(string search);
    }
}
