using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Entities;

namespace Web.Entities.Dtos
{
   public class UseForLoginDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
