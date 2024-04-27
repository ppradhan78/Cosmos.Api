namespace Cosmos.MongoDbAPI.Data.BusinessObjects.Base
{
    public abstract class BaseCore<TEntity> : IBaseCore<TEntity> where TEntity : class
    {
        IBaseRepository<TEntity> _repository;

        public BaseCore(IBaseRepository<TEntity> repository)
        {
            _repository = repository;   
        }

        public Task Create(TEntity obj)
        {
            if (obj==null)
            {
                throw new Exception("Invalid Input");
            }
            return  _repository.Create(obj);
        }

        public Task<bool> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Invalid Id");
            }
            return _repository.Delete(id);
        }

        public Task<TEntity> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Invalid Id");
            }
            return _repository.Get(id);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return  _repository.GetAll();
        }

        public Task<IEnumerable<TEntity>> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new Exception("Invalid search");
            }
            return _repository.Search(search);
        }

        public Task<bool> Update(TEntity obj)
        {
            if (obj == null)
            {
                throw new Exception("Invalid Input");
            }
            return _repository.Update(obj);
        }
    }
}
