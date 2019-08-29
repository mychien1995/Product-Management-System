using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models;
using ProductMS.Services.Abstractions;

namespace ProductMS.Services
{
    public interface IOrganizationService : IModelService<OrganizationModel>
    {

    }
    public class OrganizationService : BaseModelService<OrganizationModel, Organization>, IOrganizationService
    {
        private readonly IOrganizationRepository _repository;
        public OrganizationService(IOrganizationRepository repository, IModelTransformer<OrganizationModel, Organization> transformer) : base(repository, transformer)
        {
            _repository = repository;
        }
    }
}

