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
    public class ArticlesController : BaseController
    {
        private readonly IArticleService _service;
        public ArticlesController(IArticleService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<OperationResult<List<ArticleModel>>> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<OperationResult<ArticleModel>> Get(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public ActionResult<OperationResult<int>> Insert(ArticleModel model)
        {
            var result = _service.Insert(model);
            return new OperationResult<int>(result.Data.ArticleId);
        }

        [HttpPut("{id}")]
        public ActionResult<OperationResult<int>> Update(int id, [FromBody]ArticleModel model)
        {
            model.ArticleId = id;
            var result = _service.Update(model);
            return new OperationResult<int>(result.Data.ArticleId);
        }

        [HttpDelete("{id}")]
        public ActionResult<OperationResult> Delete(int id, ArticleModel model)
        {
            return _service.Delete(model);
        }
    }
}

