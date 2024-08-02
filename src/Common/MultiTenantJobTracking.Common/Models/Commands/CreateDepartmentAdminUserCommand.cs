namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateDepartmentAdminUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
