using ProductMS.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services
{
    public interface IModelService<TModel> where TModel : class
    {
        OperationResult<List<TModel>> GetAll();
        OperationResult<TModel> GetById(object id);
        OperationResult<TModel> Insert(TModel t);
        OperationResult<TModel> Update(TModel t);
        OperationResult Delete(object id);
    }
}
