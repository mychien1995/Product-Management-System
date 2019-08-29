using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models;

using ProductMS.Services.Abstractions;
namespace ProductMS.Services
{
    public interface IProductService : IModelService<ProductModel>
    {

    }
    public class ProductService : BaseModelService<ProductModel, Product>, IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository, IModelTransformer<ProductModel, Product> transformer) : base(repository, transformer)
        {
            _repository = repository;
        }
    }
}
