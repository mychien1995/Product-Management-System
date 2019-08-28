using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ProductMS.Api.Models;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Models.Users;
using ProductMS.Services.Abstractions.Interfaces;
using ProductMS.Services.Services.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserManager _userManager;
        private ITokenService _tokenService;
        public AuthenticationController(IUserManager userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<ActionResult> Authenticate([FromBody] UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _userManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }
                var user = await _userManager.FindUserByName(model.Username);
                return Ok(_tokenService.GetToken(user));

            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    UserName = registerModel.Username,
                    Email = registerModel.Email,
                    Fullname = registerModel.Fullname
                };

                var identityResult = await this._userManager.CreateAsync(user, registerModel.Password);
                if (identityResult.Succeeded)
                {
                    await _userManager.SignInAsync(user, isPersistent: false);
                    return Ok(_tokenService.GetToken(user));
                }
                else
                {
                    return BadRequest(identityResult.Errors);
                }
            }
            return BadRequest(ModelState);


        }
    }
}
