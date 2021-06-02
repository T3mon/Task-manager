using BLL.Service.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_manager.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _admninService;

        public AdminController(IAdminService admninService)
        {
            _admninService = admninService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetUser")]
        public async Task<List<User>> GetUser()
        {
            return await _admninService.GetAllUsers();
        }
    }
}
