using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Repositories
{
    public interface IOrganizationRepository : IEntityRepository<Organization>
    {

    }

    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ProductDbContext context) : base(context)
        {

        }
    }
}

