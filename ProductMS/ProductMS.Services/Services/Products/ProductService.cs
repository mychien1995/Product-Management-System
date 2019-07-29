using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Products
{
    public interface IProductService : IModelService<ProductModel>
    {

    }
    public class ProductService : BaseModelService<ProductModel>, IProductService
    {
        private readonly IProductDataProvider _provider;
        public ProductService(IProductDataProvider provider) : base(provider)
        {
            _provider = provider;
        }
    }
}
