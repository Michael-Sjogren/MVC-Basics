using System.Collections.Generic;

namespace MVCBasics.Models.Interfaces
{
    public interface IRepository<T , K>
    {
        public void SaveChanges();
        public ICollection<T> GetAll();
        public T GetOne(K id);
        public void DeleteOne(K id);
    }
}