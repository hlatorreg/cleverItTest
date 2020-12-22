using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using cleverit.Services;
using cleverit.Models;
namespace cleverit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUserService userService;

        public IndexModel(ILogger<IndexModel> logger, IUserService user)
        {
            _logger = logger;
            userService = user;
        }

        public async void OnGet()
        {
            var users = await userService.Users();

            var user = new User();

            user.Apellido = "testo";
            user.Email = "testo";
            user.Id = "testo";
            user.Lastname = "testo";
            user.Name = "testo";
            user.Profesion = "testo";
            user.Nombre = "testo";

            await userService.AddUser(user);
        }
    }
}
