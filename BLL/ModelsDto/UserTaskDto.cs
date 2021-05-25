using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDto
{
    public class UserTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
