using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN232.LMS.Models.RequestModel
{
    public class LoginRequest
    {
        public string UserName { get; set; } = string.Empty;

        public string PassWord { get; set; } = string.Empty;
    }
}