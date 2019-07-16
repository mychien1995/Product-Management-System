using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProductMS.Services
{
    public interface IEntityService<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        T Insert(T t);
        T Update(T t);
        bool Delete(object id);
        void SaveChanges();
    }
}
