using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelsDto
{
    public class UserForLoginDto
    {
        [Required(ErrorMessage ="Email is requierd")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Password is requierd")]
        public string Password { get; set; }

    }
}
