using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProj.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> UserExist(string email)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);
            return user != null;
        }

        // Exempel på en icke-asynkron metod
        //public bool UserExist_NotAsync(string email)
        //{
        //    IdentityUser user = _userManager.FindByNameAsync(email).Result;
        //    return user != null;
        //}

        public async Task<bool> IsInRoleAsync(string email, string rolename)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);

            try
            {
                return await _userManager.IsInRoleAsync(user, rolename);
            } catch
            {
                return false;
            } 
        }

        public async Task<bool> RoleExistsAsync(string rolename)
        {
            return await _roleManager.RoleExistsAsync(rolename);
        }

        public async Task CreateRoleAsync(string rolename)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = rolename });
        }

        public async Task AddToRoleAsync(string email, string rolename)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);
            await _userManager.AddToRoleAsync(user, rolename);
        }



        public async Task CreateTestUsers()
        {
            await CreateUserWithRoleIfNotExist("superadmin@gmail.com", "SuperAdmin", "aQ!234567890");
            await CreateUserWithRoleIfNotExist("lise@lotte.se", "CategoryAdmin", "aQ!234567890");
            await CreateUserIfNotExist("dennis@bonde.se", "aQ!234567890");
        }



        private async Task CreateUserWithRoleIfNotExist(string email, string role, string password)
        {
            await CreateUserIfNotExist(email, password);
            await CreateRole(role);
            IdentityUser user = await _userManager.FindByNameAsync(email);
            await AddRoleToUser(role, user);
        }

        public async Task<IList<string>> GetRolesForUser(string email)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);

            return await _userManager.GetRolesAsync(user);
        }

        public async Task SignInByEmail(string email)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);
            await _signInManager.SignInAsync(user, true);
        }


        private async Task AddRoleToUser(string role, IdentityUser user)
        {
            if (!await _userManager.IsInRoleAsync(user, role))
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                    throw new Exception($"Couldn't add role {role} to {user.Email}");
            }
        }

        private async Task CreateRole(string role)
        {
            bool roleExist = await RoleExistsAsync(role); // _roleManager.RoleExistsAsync(role);

            if (!roleExist)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                    throw new Exception($"Couldn't create role {role}");
            }
        }

        private async Task CreateUserIfNotExist(string email, string password)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                IdentityResult result = await _userManager.CreateAsync(new IdentityUser(email), password);
                if (!result.Succeeded)
                    throw new Exception($"Couldn't create user {email}");
            }

        }

    }
}
