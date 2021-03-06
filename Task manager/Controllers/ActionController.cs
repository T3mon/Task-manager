using BLL.ModelsDto;
using BLL.Service.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_manager.Controllers
{
    [Route("api/action")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _actionService;

        public ActionController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpGet("GetTasks")]
        public async Task<List<UserTaskDto>> GetTasks()
        {
            return await _actionService.GetAllTasks();
        }
        [HttpDelete("DeleteTask")]
        public async Task DeleteTask(string Id)
        {
            await _actionService.DeleteTask(Id);
        }
    }
}
