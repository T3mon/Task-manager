using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserTask
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public Status Status{ get; set; }
    }
}
