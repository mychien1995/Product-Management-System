using System;
using System.Collections.Generic;
using System.Text;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models;
using ProductMS.Services.Abstractions;

namespace ProductMS.DataAccess.SqlServer
{
    public class OrganizationEntityTransformer : IModelTransformer<OrganizationModel, Organization>
    {
        public Organization ToProviderData(OrganizationModel model)
        {
            if (model == null) return null;
            return new Organization()
            {
                OrganizationId = model.OrganizationId,
                OrganizationName = model.OrganizationName,
                CMSHostNames = model.CMSHostNames,
                WebHostNames = model.WebHostNames,
                ProvinceId = model.ProvinceId,
                CreatedDate = model.CreatedDate,
                IsActive = model.IsActive,
                IsDeleted = model.IsDeleted,
                UpdatedDate = model.UpdatedDate
            };
        }

        public OrganizationModel ToModel(Organization entity)
        {
            if (entity == null || !(entity is Organization)) return null;
            return new OrganizationModel()
            {
                OrganizationId = entity.OrganizationId,
                OrganizationName = entity.OrganizationName,
                CMSHostNames = entity.CMSHostNames,
                WebHostNames = entity.WebHostNames,
                ProvinceId = entity.ProvinceId,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsActive,
                IsDeleted = entity.IsDeleted,
                UpdatedDate = entity.UpdatedDate
            };
        }
    }
}

