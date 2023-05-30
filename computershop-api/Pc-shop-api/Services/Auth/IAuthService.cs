using computershopAPI.Dtos.Token;
using computershopAPI.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace computershopAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<Boolean> UserExists(string username);
        Task<Boolean> AddUser(RegisterModel model);
        Task<ServiceResponse<TokenDto>> DoLogin(LoginModel model);
        Task<User> GetUserById(string id); 
    }
}
