using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Services
{
    public class ApiBaseService
    {
        protected static HttpClientBase HttpClientBase = new HttpClientBase();

        public static readonly string BaseUrl = "http://imgurvinderbini-001-site1.htempurl.com/";

        public static readonly string GetContacts = "api/Device/GetContacts?DeviceId={0}&PhoneNumber={1}";

        public static readonly string InsertContact = "api/Device/{0}";
    }
}
