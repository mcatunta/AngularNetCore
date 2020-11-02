using Microsoft.Extensions.DependencyInjection;
using SalesDiego.Api.Repositories.Impl;
using SalesDiego.Api.Repositories.Intefaces;
using SalesDiego.Api.Services.Impl;
using SalesDiego.Api.Services.Intefaces;
using SalesDiego.Api.ServicesImpl;

namespace SalesDiego.Api
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, GenericRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
