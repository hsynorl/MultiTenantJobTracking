using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.CustomExceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Geçersiz kimlik bilgileri hatası.")
        {
        }

        public InvalidCredentialsException(string message) : base(message)
        {
        }
        public InvalidCredentialsException(string username, string password) : base($"Geçersiz kimlik bilgileri hatası. Kullanıcı adı: {username} Şifre: {password}")
        {
        }
    }
}
