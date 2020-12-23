using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using cleverit.Services;
using cleverit.Models;
using System.Net;

namespace cleverit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUserService userService;
        public List<User> userList = new List<User>();

        public IndexModel(ILogger<IndexModel> logger, IUserService user)
        {
            _logger = logger;
            userService = user;
        }

        public async Task OnGet(string token)
        {
            ViewData["token"] = token;
            var users = await userService.Users();
            userList = users;
            ViewData["users"] = users;
        }

    }
}
