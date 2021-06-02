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

        private readonly UserManager<User> _userManager;
        public AdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
