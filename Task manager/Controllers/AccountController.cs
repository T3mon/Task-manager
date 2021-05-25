using BLL.Infrastructure;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_manager.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return null;
        }
        //public IActionResult Login()
        //{

        //}
        //public IActionResult Register()
        //{

        //}

        //public IActionResult List()
        //{

        //}

    }
}
