using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Repositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {

    }

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {

        }
    }
}
