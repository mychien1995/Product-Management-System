using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Providers
{
    public class ProductDataProvider : BaseEntityDataProvider<ProductModel, Product>, IProductDataProvider
    {
        private readonly IProductRepository _productRepository;
        public ProductDataProvider(IProductRepository repository, IModelTransformer<ProductModel, Product> transformer)
            : base(repository, transformer)
        {
            _productRepository = repository;
        }
    }
}
