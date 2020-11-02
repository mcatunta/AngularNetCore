using SalesDiego.Api.Dtos;

namespace SalesDiego.Api.Services.Intefaces
{
    public interface IClientService
    {
        void Login(LoginDto login);
        void CreateClient(ClientDto user);

    }
}
