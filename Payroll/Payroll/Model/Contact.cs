using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Model
{
    public class Contact
    {
        public Int32 EntryID { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public string DeviceID { get; set; }
        public bool IsVarified { get; set; }
    }
}
