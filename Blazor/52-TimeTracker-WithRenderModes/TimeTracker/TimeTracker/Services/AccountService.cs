using Microsoft.AspNetCore.Identity;
using TimeTracker.Domain.Dtos.Account;
using TimeTracker.Domain.Entities;

namespace TimeTracker.Server.Services
{
    public sealed class AccountService(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager) : IAccountService
    {
        public async Task AssignRole(string userName, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await userManager.FindByNameAsync(userName);
            await userManager.AddToRoleAsync(user!, roleName);
        }

        public async Task<AccountRegistrationResponseDto> RegisterAsync(AccountRegistrationRequestDto request)
        {
            User newUser = new()
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };
            IdentityResult result = await userManager.CreateAsync(newUser, request.Password);

            if (!result.Succeeded)
            {
                return new AccountRegistrationResponseDto(
                    false,
                    result.Errors.Select(e => e.Description)
                );
            }

            return new AccountRegistrationResponseDto(true);
        }
    }
}
