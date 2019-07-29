using System;
using System.Collections.Generic;
using System.Linq;
using ProductMS.Services.Abstractions;

namespace ProductMS.Services
{
    public class BaseModelService<TModel> : IModelService<TModel> where TModel : class 
    {
        protected IBaseDataProvider<TModel> _dataProvider;
        public BaseModelService(IBaseDataProvider<TModel> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public bool Delete(object id)
        {
            return _dataProvider.Delete(id);
        }

        public List<TModel> GetAll()
        {
            return _dataProvider.GetAll();
        }

        public TModel GetById(object id)
        {
            return _dataProvider.GetById(id);
        }

        public TModel Insert(TModel t)
        {
            return _dataProvider.Insert(t);
        }

        public void SaveChanges()
        {
            _dataProvider.SaveChanges();
        }

        public TModel Update(TModel t)
        {
            return _dataProvider.Update(t);
        }
    }
}
