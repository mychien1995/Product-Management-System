using Microsoft.AspNetCore.Identity;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.IoC;
using ProductMS.Models;
using ProductMS.Services.Abstractions.Interfaces;
using System.Threading.Tasks;

namespace ProductMS.DataAccess.SqlServer.Repositories.Users
{
    [ServiceTypeOf(typeof(IUserManager))]
    public class EntityUserManager : IUserManager
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private UserEntityTransformer _userEntityTransformer;
        public EntityUserManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userEntityTransformer = new UserEntityTransformer();
        }
        public async Task<UserModel> FindUserByName(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            return _userEntityTransformer.ToModel(applicationUser);
        }

        public async Task<IdentityResult> CreateAsync(UserModel user, string password)
        {
            var entity = _userEntityTransformer.ToProviderData(user);
            return await _userManager.CreateAsync(entity, password);
        }

        public async Task SignInAsync(UserModel user, bool isPersistent)
        {
            var entity = _userEntityTransformer.ToProviderData(user);
            await _signInManager.SignInAsync(entity, isPersistent: isPersistent);
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }
    }
}
