﻿using BLL.ModelsDto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface IAdminService
    {
        Task<List<User>> GetAllUsers();
        void AddTask(UserTaskDto userTaskDto);
    }
}
