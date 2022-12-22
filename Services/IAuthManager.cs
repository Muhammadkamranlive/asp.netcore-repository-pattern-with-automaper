using Trevoir.DTOS;

namespace Trevoir.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDTO userLoginDTO);
        Task<string> CreateToken();


    }
}
