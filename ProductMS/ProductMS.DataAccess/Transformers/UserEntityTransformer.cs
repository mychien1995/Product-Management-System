using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.IoC;
using ProductMS.Models;
using ProductMS.Services.Abstractions;

namespace ProductMS.DataAccess.SqlServer
{
    [ServiceTypeOf(typeof(IModelTransformer<UserModel, ApplicationUser>))]
    public class UserEntityTransformer : IModelTransformer<UserModel, ApplicationUser>
    {
        public UserModel ToModel(ApplicationUser entity)
        {
            if (entity == null) return null;
            return new UserModel()
            {

                Id = entity.Id,
                UserName = entity.UserName,
                NormalizedUserName = entity.NormalizedUserName,
                Email = entity.Email,
                NormalizedEmail = entity.NormalizedEmail,
                EmailConfirmed = entity.EmailConfirmed,
                PasswordHash = entity.PasswordHash,
                SecurityStamp = entity.SecurityStamp,
                ConcurrencyStamp = entity.ConcurrencyStamp,
                PhoneNumber = entity.PhoneNumber,
                PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                TwoFactorEnabled = entity.TwoFactorEnabled,
                LockoutEnd = entity.LockoutEnd,
                LockoutEnabled = entity.LockoutEnabled,
                AccessFailedCount = entity.AccessFailedCount,
                Fullname = entity.Fullname,
                IsActive = entity.IsActive,
                CreatedDate = entity.CreatedDate,
                IsDeleted = entity.IsDeleted,
                UpdatedDate = entity.UpdatedDate
            };
        }

        public ApplicationUser ToProviderData(UserModel model)
        {
            if (model == null) return null;
            return new ApplicationUser()
            {

                Id = model.Id,
                UserName = model.UserName,
                NormalizedUserName = model.NormalizedUserName,
                Email = model.Email,
                NormalizedEmail = model.NormalizedEmail,
                EmailConfirmed = model.EmailConfirmed,
                PasswordHash = model.PasswordHash,
                SecurityStamp = model.SecurityStamp,
                ConcurrencyStamp = model.ConcurrencyStamp,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
                TwoFactorEnabled = model.TwoFactorEnabled,
                LockoutEnd = model.LockoutEnd,
                LockoutEnabled = model.LockoutEnabled,
                AccessFailedCount = model.AccessFailedCount,
                Fullname = model.Fullname,
                IsActive = model.IsActive,
                CreatedDate = model.CreatedDate,
                IsDeleted = model.IsDeleted,
                UpdatedDate = model.UpdatedDate
            };
        }
    }
}
