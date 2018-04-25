using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Payroll.Model
{
    public class BaseBO
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
