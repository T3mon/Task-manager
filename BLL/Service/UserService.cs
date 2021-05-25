using BLL.Infrastructure;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }


        Task IUserService.Login()
        {
            throw new NotImplementedException();
        }

    }
}
