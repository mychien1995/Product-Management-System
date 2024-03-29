﻿using Microsoft.AspNetCore.Identity;
using ProductMS.Models;
using System.Threading.Tasks;

namespace ProductMS.Services.Abstractions.Interfaces
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(UserModel user, string password);
        Task<UserModel> FindUserByName(string userName);

        Task SignInAsync(UserModel user, bool isPersistent);

        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    }
}
