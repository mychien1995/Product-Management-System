using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductMS.Models.Common;
using ProductMS.Models;
using ProductMS.Services;

namespace ProductMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : BaseController
    {
        private readonly IOrganizationService _service;
        public OrganizationsController(IOrganizationService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<OperationResult<List<OrganizationModel>>> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<OperationResult<OrganizationModel>> Get(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public ActionResult<OperationResult<int>> Insert(OrganizationModel model)
        {
            var result = _service.Insert(model);
            return new OperationResult<int>(result.Data.OrganizationId);
        }

        [HttpPut("{id}")]
        public ActionResult<OperationResult<int>> Update(int id, [FromBody]OrganizationModel model)
        {
            model.OrganizationId = id;
            var result = _service.Update(model);
            return new OperationResult<int>(result.Data.OrganizationId);
        }

        [HttpDelete("{id}")]
        public ActionResult<OperationResult> Delete(int id, OrganizationModel model)
        {
            return _service.Delete(model);
        }
    }
}

