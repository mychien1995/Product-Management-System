namespace ProductMS.Services.Abstractions
{
    public interface IModelTransformer<TModel, TData>
    {
        TModel ToModel(TData entity);

        TData ToProviderData(TModel model);
    }
}
