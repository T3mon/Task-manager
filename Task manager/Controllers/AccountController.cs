using AutoMapper;
using BLL.Infrastructure;
using BLL.Service;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMapper _mapper;
        //Identity
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountController(IUserService userService, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userService = userService;
            _mapper = mapper;


            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return null;
        }
        [HttpPost("Login")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(User model, string returnUrl = "")
        {
            if (!TryValidateModel(model)) return StatusCode(500);
            var user = new User()
            {
                PasswordHash = model.PasswordHash,
                UserName = model.UserName
            };
            var res = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, false);
            if (res.Succeeded)
            {
                return StatusCode(200);
            }
            return StatusCode(204);
        }

        //public IActionResult Register()
        //{

        //}

        //public IActionResult List()
        //{

        //}

    }
}
