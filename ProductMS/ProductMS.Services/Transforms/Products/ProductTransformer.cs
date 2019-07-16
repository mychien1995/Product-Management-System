using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Interfaces;
using ProductMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Transforms
{
    public class ProductTransformer : IModelTransformer<ProductModel>
    {
        public ProductModel ToModel(IModelTransformable<ProductModel> entity)
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

        IModelTransformable<ProductModel> IModelTransformer<ProductModel>.ToEntity(ProductModel model)
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
    }
}
