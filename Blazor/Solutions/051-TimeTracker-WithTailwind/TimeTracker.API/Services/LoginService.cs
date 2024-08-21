using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeTracker.Domain.Dtos.Login;
using TimeTracker.Domain.Entities;

namespace TimeTracker.API.Services
{
    public class LoginService(SignInManager<User> signInManager,
        UserManager<User> userManager, IConfiguration configuration) : ILoginService
    {
        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(
                request.UserName, request.Password, false, false);

            if (!result.Succeeded)
            {
                return new LoginResponseDto(false, "Incorrect username or password.");
            }

            User? user = await userManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                return new LoginResponseDto(false, "User doesn't exist.");
            }

            IList<string> roles = await userManager.GetRolesAsync(user);

            List<Claim> claims = [
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            ];
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(
                                       configuration["JwtSecurityKey"]!));

            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            DateTime expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["JwtExpiryInDays"]));

            JwtSecurityToken token = new(
                issuer: configuration["JwtIssuer"],
                audience: configuration["JwtAudience"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponseDto(true, Token: jwt);
        }
    }
}
