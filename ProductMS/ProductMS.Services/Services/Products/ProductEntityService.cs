using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Products
{
    public interface IProductService : IEntityService<Product>
    {

    }
    public class ProductEntityService : BaseEntityService<Product>, IProductEntityService
    {
        private readonly IProductRepository _productRepository;
        public ProductEntityService(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }
    }
}
