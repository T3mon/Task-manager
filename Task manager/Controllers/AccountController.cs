using AutoMapper;
using BLL.Infrastructure;
using BLL.ModelsDto;
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
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost("Login")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForRegistration)
        {
            if (!TryValidateModel(userForRegistration)) return StatusCode(500);
            var user = new User()
            {
                UserName = userForRegistration.Email
            };
            var res = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, false);
            if (res.Succeeded)
            {
                return StatusCode(200);
            }
            return StatusCode(204);
        }

    }
}
