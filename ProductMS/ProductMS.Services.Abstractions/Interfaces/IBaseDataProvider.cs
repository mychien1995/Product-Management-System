using System.Collections.Generic;

namespace ProductMS.Services.Abstractions
{
    public interface IBaseDataProvider<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        T Insert(T t);
        T Update(T t);
        bool Delete(object id);
        void SaveChanges();
    }
}