using BLL.Service.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AdminService : IAdminService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AdminService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser()
        {
            throw new NotImplementedException();
        }
    }
}
