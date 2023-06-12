using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Helpers;
using MovieProps.BLL.Contract.Services;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("GetAllSellers")]
        public async Task<IActionResult> GetAllSellers()
        {
            return Ok(await _userService.GetAllSellers());
        }

        [HttpPost("Approve/{email}")]
        public async Task<IActionResult> ApproveSeller(string email)
        {
            return Ok(await _userService.ApproveSeller(email));
        }

        [HttpPost("Reject/{email}")]
        public async Task<IActionResult> RejectSeller(string email)
        {
            return Ok(await _userService.RejectSeller(email));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromForm] UserDataIn dataIn)
        {
            return Ok(await _userService.Update(dataIn));
        }
    }
}
