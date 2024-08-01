namespace MultiTenantJobTracking.Common.CustomExceptions
{
    public class ExistingRecordException : Exception
    {
        public ExistingRecordException() : base("Kayıt zaten mevcut")
        {
        }

        public ExistingRecordException(string message) : base(message)
        {
        }

    }
}
