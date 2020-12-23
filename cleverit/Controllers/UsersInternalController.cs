using Microsoft.AspNetCore.Mvc;
using cleverit.Services;
using cleverit.Models;
using System.Threading.Tasks;

namespace cleverit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var results = await _userService.Users();
            return Ok(results);
        }

        [Authorize]
        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var results = await _userService.Users(id);
            if (string.IsNullOrWhiteSpace(results.Id))
                return NotFound();
            return Ok(results);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(User model)
        {
            var results = await _userService.AddUser(model);
            var response = new UserOperationsResponse(results, "created");
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Update(User model, string id)
        {
            var results = await _userService.UpdateUser(id, model);
            var response = new UserOperationsResponse(results, "updated");
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var results = await _userService.DeleteUser(id);
            var response = new UserOperationsResponse(results, "deleted");
            return Ok(response);
        }
    }
}