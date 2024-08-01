using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Kayıt bulunamadı")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
     
    }

}
