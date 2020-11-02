using System;
using System.Linq;
using SalesDiego.Api.Commons;
using SalesDiego.Api.Dtos;
using SalesDiego.Api.Entities;
using SalesDiego.Api.Repositories.Intefaces;
using SalesDiego.Api.Services.Intefaces;

namespace SalesDiego.Api.ServicesImpl
{
    public class ClientService : IClientService
    {
        private IGenericRepository _genericRepository;
        
        public ClientService(IGenericRepository userRepository)
        {
            _genericRepository = userRepository;
        }

        public void Login(LoginDto login)
        {
            var user = _genericRepository.Filter<Client>(p => p.Email == login.UserName
                && p.Password == Security.Encrypt(login.Password)).FirstOrDefault();
            if (user == null)
                throw new ApplicationException("Credenciales inválidas");
        }

        public void CreateClient(ClientDto clientDto)
        {
            var client = _genericRepository.Filter<Client>(p => p.Email == clientDto.Email).FirstOrDefault();
            if (client != null)
                throw new ApplicationException("El usuario ya existe");
            var newClient = new Client()
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                Password = Security.Encrypt(clientDto.Password)
            };
            _genericRepository.Add(newClient);
            _genericRepository.SaveChanges();
        }
    }
}
