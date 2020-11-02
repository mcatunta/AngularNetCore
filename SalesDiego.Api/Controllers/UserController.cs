using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesDiego.Api.Dtos;
using SalesDiego.Api.Services.Intefaces;

namespace SalesDiego.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : BaseController
    {
        private IConfiguration _configuration;
        private IUserService _userService;
        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<LoggedInDto> Login(LoginDto login)
        {
            return Execute(() =>
            {
                return _userService.Login(login);
            });
        }


    }
}
