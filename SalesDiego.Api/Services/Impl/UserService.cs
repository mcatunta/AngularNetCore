using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SalesDiego.Api.Commons;
using SalesDiego.Api.Dtos;
using SalesDiego.Api.Entities;
using SalesDiego.Api.Repositories.Intefaces;
using SalesDiego.Api.Services.Intefaces;

namespace SalesDiego.Api.Services.Impl
{
    public class UserService : IUserService
    {
        private IGenericRepository _genericRepository;
        private IConfiguration _configuration;
        public UserService(IConfiguration configuration, IGenericRepository genericRepository)
        {
            _configuration = configuration;
            _genericRepository = genericRepository;
        }

        public LoggedInDto Login(LoginDto login)
        {
            var user = _genericRepository.Filter<User>(p => p.UserName == login.UserName
                && p.Password == Security.Encrypt(login.Password)).FirstOrDefault();
            if (user == null)
                throw new ApplicationException("Credenciales inválidas.");
            return new LoggedInDto()
            {
                Name = login.UserName,
                UserName = login.UserName,
                Token = Security
                    .GenerarTokenJWT(login.UserName, _configuration["AppSettings:Token.Key"]
                    , Security.Roles.ADMIN),
                Rol = Security.Roles.ADMIN
            };
        }
    }
}
