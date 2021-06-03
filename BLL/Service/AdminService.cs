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
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;
        private readonly IApplicationDbContext _applicationDbContext;
        public AdminService(UserManager<User> userManager, IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public void AddTask(UserTaskDto userTaskDto)
        {
            UserTask userTask = new UserTask()
            {
                Title = userTaskDto.Title,
                Description = userTaskDto.Description,
                Status = userTaskDto.Status,
                UserId = _userManager.Users.FirstOrDefault(m => m.Email == userTaskDto.AssignedTo).Id
            };

            _applicationDbContext.UserTasks.Add(userTask);

            _applicationDbContext.SaveChanges();

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
