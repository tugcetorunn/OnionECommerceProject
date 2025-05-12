using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnionProject.Application.Layer.Models.DTOs.Login;
using OnionProject.Core.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Layer.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<Uye> userManager;
        // private readonly RoleManager<Rol> roleManager;
        private readonly IMapper mapper;
        public LoginService(UserManager<Uye> _userManager, IMapper _mapper)
        {
            userManager = _userManager;
            mapper = _mapper;
        }
        public async Task<LoginResultDTO> LoginAsync(LoginDTO login)
        {
            var user =  await userManager.FindByNameAsync(login.UserName);
            LoginResultDTO loginResult = new LoginResultDTO()
            {
                UyeId = -1,
                IsAdmin = false
            };

            if (user != null)
            {
                bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, login.Password);
                //if (isPasswordCorrect)
                //{
                //    var roles = await userManager.GetRolesAsync(user);
                //    var role = roles.FirstOrDefault();
                //    if (role != null)
                //    {
                //        var roleId = await roleManager.FindByNameAsync(role);
                //        return roleId.Id;
                //    }
                //}

                if (isPasswordCorrect)
                {
                    loginResult.UyeId = user.Id;
                    loginResult.IsAdmin = await userManager.IsInRoleAsync(user, "Admin");
                }
            }

            return loginResult;
        }

        public async Task<bool> RegisterAsync(RegisterDTO register)
        {
            Uye uye = new Uye();
            mapper.Map(register, uye);
            var result = await userManager.CreateAsync(uye, register.Password);
            await userManager.AddToRoleAsync(uye, "Uye");
            return result.Succeeded;
        }

        public async Task<Uye> UyeGetirAsync(ClaimsPrincipal claims)
        {
            return await userManager.GetUserAsync(claims);
        }

        public async Task<Uye> UyeGetirAsync(int id)
        {
            return await userManager.FindByIdAsync(id.ToString());
        }
    }
}
