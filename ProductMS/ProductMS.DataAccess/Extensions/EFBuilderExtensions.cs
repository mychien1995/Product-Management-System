using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductMS.DataAccess.SqlServer.Entities;
using System;
using System.Reflection;

namespace ProductMS.DataAccess.SqlServer.Extensions
{
    public static class EFBuilderExtensions
    {
        public static IdentityBuilder AddCustomEFStore<TContext>(this IdentityBuilder builder)
            where TContext : DbContext
        {
            AddStores(builder.Services, builder.UserType, builder.RoleType, typeof(TContext));
            return builder;
        }

        private static void AddStores(IServiceCollection services, Type userType, Type roleType, Type contextType)
        {
            var identityUserType = FindGenericBaseType(userType, typeof(IdentityUser<>));
            if (identityUserType == null)
            {
                throw new InvalidOperationException("No IdentityUser type defined");
            }

            var keyType = identityUserType.GenericTypeArguments[0];
            var identityRoleType = FindGenericBaseType(roleType, typeof(IdentityRole<>));
            if (identityRoleType == null)
            {
                throw new InvalidOperationException("No IdentityRole type defined");
            }
            Type userClaimType = typeof(ApplicationUserClaim);
            Type userRoleType = typeof(ApplicationUserRole);
            Type userLoginType = typeof(ApplicationUserLogin);
            Type userTokenType = typeof(ApplicationUserToken);
            Type roleClaimType = typeof(ApplicationRoleClaim);
            Type userStoreType = typeof(UserStore<,,,,,,,,>).MakeGenericType(userType, roleType, contextType, keyType,
                    userClaimType,
                    userRoleType,
                    userLoginType,
                    userTokenType,
                    roleClaimType);
            Type roleStoreType = typeof(RoleStore<,,,,>).MakeGenericType(roleType, contextType,
                keyType,
                userRoleType,
                roleClaimType);
            services.TryAddScoped(typeof(IUserStore<>).MakeGenericType(userType), userStoreType);
            services.TryAddScoped(typeof(IRoleStore<>).MakeGenericType(roleType), roleStoreType);

        }

        private static TypeInfo FindGenericBaseType(Type currentType, Type genericBaseType)
        {
            var type = currentType;
            while (type != null)
            {
                var typeInfo = type.GetTypeInfo();
                var genericType = type.IsGenericType ? type.GetGenericTypeDefinition() : null;
                if (genericType != null && genericType == genericBaseType)
                {
                    return typeInfo;
                }
                type = type.BaseType;
            }
            return null;
        }
    }
}
