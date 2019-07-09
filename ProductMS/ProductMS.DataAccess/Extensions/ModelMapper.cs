using ProductMS.DataAccess.Entities;
using ProductMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.Extensions
{
    public static class ModelMapper
    {
        #region Product
        public static ProductModel ToModel(this Product entity)
        {
            if (entity == null) return null;
            return new ProductModel()
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                ProductDescription = entity.ProductDescription,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                ImageUrl = entity.ImageUrl
            };
        }

        public static Product ToEntity(this ProductModel model)
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
        #endregion
    }
}
