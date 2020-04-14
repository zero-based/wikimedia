using System.Collections.Generic;

namespace Infrastructure
{
    public interface IRepository<T>
    {
        void Create(T obj);
        T Get(string id);
        IEnumerable<T> GetAll();
        void Update(string id);
        void Delete(string id);
    }
}
