using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Interfaces;
using ProductMS.Models.Products;
using ProductMS.Services.Transforms;
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
        public ProductService(IEntityService<IModelTransformable<ProductModel>> entityService,
            IModelTransformer<ProductModel> modelTransformer)
            : base(entityService, modelTransformer)
        {

        }
    }
}
