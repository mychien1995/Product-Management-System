using ProductMS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Transforms
{
    public interface IModelTransformer<TModel>
    {
        TModel ToModel(IModelTransformable<TModel> entity);

        IModelTransformable<TModel> ToEntity(TModel model);
    }
}
