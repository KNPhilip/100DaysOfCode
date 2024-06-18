using DataAccess;
using Domain.Dtos;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Services;

public class AuthService(IConfiguration configuration, UserRepository userRepository)
{
    private readonly IConfiguration _configuration = configuration;
    private readonly UserRepository _userRepository = userRepository;

    public virtual async Task<string?> LoginAsync(LoginDto request)
    {
        User? user = await _userRepository.GetUserByEmailAsync(request.Email);   
        if (user is null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return null;
        }

        return CreateJwt(request.Email) ?? null;
    }

    public virtual async Task<bool> RegisterAsync(RegisterDto request)
    {
        User? user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is not null)
        {
            return false;
        }

        user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userRepository.CreateUserAsync(user);
        return true;
    }

    private string CreateJwt(string userEmail)
    {
        List<Claim> claims = [
            new(ClaimTypes.Email, userEmail),
            new(ClaimTypes.Role, "User")
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["EncryptionKey"] 
            ?? throw new Exception("The encryption key was not set.")));

        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken token = new(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
