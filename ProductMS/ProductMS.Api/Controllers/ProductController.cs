using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Models.Products;
using ProductMS.Services.Products;

namespace ProductMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            return _productService.GetAll();
        }

        [HttpPost]
        public ActionResult<ProductModel> Post(ProductModel model)
        {
            return _productService.Insert(model);
        }
    }
}
