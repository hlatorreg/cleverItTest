using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using cleverit.Services;
using cleverit.Models;
using cleverit.Helpers;
using System.Threading.Tasks;

namespace cleverit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        public AuthController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            UserData userData = await _userService.GetUserAuth(model.Username, model.Password);
            if (string.IsNullOrWhiteSpace(userData.Password))
            {
                return NotFound();
            }
            var token = generateJwtToken(userData);
            var response = new AuthenticateResponse(token);
            return Ok(response);
        }

        private string generateJwtToken(UserData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}