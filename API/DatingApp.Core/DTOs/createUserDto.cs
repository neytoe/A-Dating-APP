using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.DTOs
{
    public class createUserDto
    {
        [Required]
        public string UserName { get; set; }
    }
}
