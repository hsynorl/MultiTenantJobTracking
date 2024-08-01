namespace MultiTenantJobTracking.Common.CustomExceptions
{
    public class LicenseExpiredException : Exception
    {
        public LicenseExpiredException() : base("Lisans süresi doldu")
        {
        }

        public LicenseExpiredException(string message) : base(message)
        {
        }
    }

}
