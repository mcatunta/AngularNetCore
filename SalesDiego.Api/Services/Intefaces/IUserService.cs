using SalesDiego.Api.Dtos;

namespace SalesDiego.Api.Services.Intefaces
{
    public interface IUserService
    {
        LoggedInDto Login(LoginDto login);
    }
}
