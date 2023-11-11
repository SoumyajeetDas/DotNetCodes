using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.Dto
{
    public class RegisterViewModelDto
    {
        public IEnumerable<Role> Roles { set; get; }
        public RegisterDto registerDto { set; get; }
    }
}