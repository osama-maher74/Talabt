using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LinkDev.Talabat.Application.Abstraction.Models.Auth;
using LinkDev.Talabat.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Application.Excpetions;
using LinkDev.Talabat.Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LinkDev.Talabat.Application.Services.Auth
{
    public class AuthService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration) : IAuthService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user is null) throw new UnAuthoraizedException("Invalid Login");
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
            if (result.IsNotAllowed) throw new UnAuthoraizedException("Account not Confirmed yet");
            if (result.IsLockedOut) throw new UnAuthoraizedException("Account is Locked");
            if (!result.Succeeded) throw new UnAuthoraizedException("Invalid Login");
            var response = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)

            };
            return response;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                throw new ValidationException(); //{ Erorrs=result.Errors.Select(E=>E.Description) };
            var response = new UserDto()
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };
            return response;    


        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var userandRolesClaims=new List<Claim>();
            var roles=await userManager.GetRolesAsync(user);

            foreach (var role in roles)
             userandRolesClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
     
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid,user.Id),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.GivenName,user.DisplayName),
                
            }
            .Union(userClaims)
            .Union(userandRolesClaims);

            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!));

            var signincreds = new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signincreds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            var email=claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email!);
            return new UserDto
            {
                Id = user!.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };


        }
    }
}
