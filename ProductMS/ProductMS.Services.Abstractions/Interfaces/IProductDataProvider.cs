using ProductMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Abstractions
{
    public interface IProductDataProvider : IBaseDataProvider<ProductModel>
    {
    }
}
