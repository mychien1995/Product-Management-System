using System;
using System.Collections.Generic;
using System.Linq;
using ProductMS.Models.Common;
using ProductMS.Models.Interfaces;
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

        public virtual OperationResult Delete(object id)
        {
            var result = _dataProvider.Delete(id);
            return new OperationResult()
            {
                IsSuccess = result
            };
        }

        public virtual OperationResult<List<TModel>> GetAll()
        {
            var data = _dataProvider.GetAll();
            return OperationResult.From(data);
        }

        public virtual OperationResult<TModel> GetById(object id)
        {
            var data = _dataProvider.GetById(id);
            return OperationResult.From(data);
        }

        public virtual OperationResult<TModel> Insert(TModel t)
        {
            if (t is IChangeTrackable)
            {
                ((IChangeTrackable)t).CreatedDate = DateTime.Now;
                ((IChangeTrackable)t).UpdatedDate = DateTime.Now;
            }
            if (t is IPreservable)
            {
                ((IPreservable)t).IsDeleted = false;
            }
            var data = _dataProvider.Insert(t);
            return OperationResult.From(data);
        }

        public virtual OperationResult<TModel> Update(TModel t)
        {
            if (t is IChangeTrackable)
            {
                ((IChangeTrackable)t).UpdatedDate = DateTime.Now;
            }
            var data = _dataProvider.Update(t);
            return OperationResult.From(data);
        }
    }
}
