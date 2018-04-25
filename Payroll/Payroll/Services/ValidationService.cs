using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payroll.Model;

namespace Payroll.Services
{
    public class ValidationService : ApiBaseService
    {
        public async Task<UserDeviceBO> ValidateUser(string deviceToken, string phoneNumber, string email)
        {
            try
            {
                var endpoint = String.Format(Validate, phoneNumber, email, deviceToken);
                var contact = await HttpClientBase.Get<UserDeviceBO>(endpoint);
                return contact;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
