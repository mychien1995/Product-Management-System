using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Models;
using ProductMS.Models.Common;
using ProductMS.Services;
using System.Collections.Generic;
namespace ProductMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<OperationResult<List<ProductModel>>> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<OperationResult<ProductModel>> Get(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public ActionResult<OperationResult<int>> Insert(ProductModel model)
        {
            var result = _productService.Insert(model);
            return new OperationResult<int>(result.Data.ProductId);
        }

        [HttpPut("{id}")]
        public ActionResult<OperationResult<int>> Update(int id, [FromBody]ProductModel model)
        {
            model.ProductId = id;
            var result = _productService.Update(model);
            return new OperationResult<int>(result.Data.ProductId);
        }

        [HttpDelete("{id}")]
        public ActionResult<OperationResult> Delete(int id, ProductModel model)
        {
            return _productService.Delete(model);
        }
    }
}
