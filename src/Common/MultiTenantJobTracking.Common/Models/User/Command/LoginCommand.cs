using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.User.Command
{
    public class LoginCommand
    {
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
