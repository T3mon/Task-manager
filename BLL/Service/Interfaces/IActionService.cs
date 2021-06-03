using BLL.ModelsDto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface IActionService
    {
        Task<List<UserTaskDto>> GetAllTasks();

    }
}
