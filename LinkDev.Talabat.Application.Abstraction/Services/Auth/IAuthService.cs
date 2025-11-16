using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Application.Abstraction.Models.Auth;

namespace LinkDev.Talabat.Application.Abstraction.Services.Auth
{
    public interface IAuthService
    {

        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto); 
        Task<UserDto> GetCurrentUser(ClaimsPrincipal claimsPrincipal); 

        //Task<AddressDto> GetUserAddress(ClaimsPrincipal claimsPrincipal);

    }
}
