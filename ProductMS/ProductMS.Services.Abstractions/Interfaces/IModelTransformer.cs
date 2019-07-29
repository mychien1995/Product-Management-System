using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Abstractions
{
    public interface IModelTransformer<TModel, TData>
    {
        TModel ToModel(TData entity);

        TData ToProviderData(TModel model);
    }
}
