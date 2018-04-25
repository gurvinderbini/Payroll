using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Payroll.Model
{
    public class UserDeviceBO : BaseBO
    {
        public Userdevice[] UserDevice { get; set; }
    }

    public class Userdevice
    {
        [JsonProperty("employeeName")]
        public string EmployeeName { get; set; }
    }
}
