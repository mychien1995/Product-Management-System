using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models.Products;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

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
