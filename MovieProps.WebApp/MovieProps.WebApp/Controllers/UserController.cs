using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Helpers;
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserDataIn dataIn)
        {
            return Ok(await _userService.RegisterUser(dataIn));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userService.GetCurrentUser());
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItemsForUser()
        {
            return Ok(await _userService.GetAllItemsForCurrentUser());
        }
    }
}
