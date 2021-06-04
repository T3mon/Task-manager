using BLL.ModelsDto;
using BLL.Service.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_manager.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService admninService)
        {
            _adminService = admninService;
        }
        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _adminService.GetAllUsers();
        }
        [HttpPost("AddTask")]
        public void AddTask([FromBody] UserTaskDto userTaskDto)
        {
            _adminService.AddTask(userTaskDto);
        }
    }
}
