using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Services;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Register(UserDataIn dataIn)
        {
            return Ok(await _userService.RegisterUser(dataIn));
        }
    }
}
