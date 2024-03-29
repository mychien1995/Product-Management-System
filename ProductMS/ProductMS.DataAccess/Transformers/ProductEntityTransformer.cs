﻿using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.IoC;
using ProductMS.Models;
using ProductMS.Services.Abstractions;
namespace ProductMS.DataAccess.SqlServer
{
    [ServiceTypeOf(typeof(IModelTransformer<ProductModel, Product>))]
    public class ProductEntityTransformer : IModelTransformer<ProductModel, Product>
    {
        public Product ToProviderData(ProductModel model)
        {
            if (model == null) return null;
            return new Product()
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                ImageUrl = model.ImageUrl
            };
        }

        public ProductModel ToModel(Product entity)
        {
            if (entity == null || !(entity is Product)) return null;
            var product = (Product)entity;
            return new ProductModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
