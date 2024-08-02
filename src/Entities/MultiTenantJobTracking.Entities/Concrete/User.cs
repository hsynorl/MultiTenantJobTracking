using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class  User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public UserType UserType { get; set; }

        public virtual TenantUser TenantUser { get; set; }
        public virtual ICollection< JobLog>  JobLogs { get; set; }
        public virtual DepartmentAdmin  DepartmentAdmin { get; set; }
        public virtual ICollection< UserJob>  UserJobs { get; set; }
        public virtual ICollection< JobComment>  JobComments { get; set; }
        public virtual  DepartmentUser  DepartmentUser{ get; set; }
    }


}
