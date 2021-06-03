using AutoMapper;
using BLL.ModelsDto;
using BLL.Service.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ActionService : IActionService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly UserManager<User> _userManager;

        public ActionService(IApplicationDbContext applicationDbContext, IMapper mapper, UserManager<User> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserTaskDto>> GetAllTasks()
        {
            List<UserTaskDto> TasksToReturn = new List<UserTaskDto>();
            List<UserTask> TasksFromDb = await _applicationDbContext.UserTasks.ToListAsync();
            foreach (var item in TasksFromDb)
            {
                TasksToReturn.Add(new UserTaskDto()
                {
                    Title = item.Title,
                    Description = item.Description,
                    Status = item.Status,
                    AssignedTo = _userManager.Users.FirstOrDefault(p => p.Id == item.UserId).Email
                });
            }

            return TasksToReturn;
        }
    }
}
