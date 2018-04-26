﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Payroll.Model
{
    public class PaySlipsBO:BaseBO
    {
        [JsonProperty("payslip")]
        public string Payslip { get; set; }
        //public string Month { get; set; }

        //public string Year { get; set; }

        //public string TotalPay { get; set; }

        //public string Deductions { get; set; }
        //public string NetPay { get; set; }
    }
}
