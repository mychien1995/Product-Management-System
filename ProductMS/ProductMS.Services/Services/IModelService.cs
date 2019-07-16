using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services
{
    public interface IModelService<TModel> where TModel : class
    {
        List<TModel> GetAll();
        TModel GetById(object id);
        TModel Insert(TModel t);
        TModel Update(TModel t);
        bool Delete(object id);
        void SaveChanges();
    }
}
