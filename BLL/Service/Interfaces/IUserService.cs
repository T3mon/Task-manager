﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public interface IUserService
    {
        Task RegisterUser();
        Task Login();
        Task<List<User>> GetAllUsers();
    }
}
