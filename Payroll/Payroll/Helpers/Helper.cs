using System;

namespace Payroll.Helpers
{
    public static class Helper
    {
        public static bool AuthenticationNeeded = true;

        public static bool IsFingerPrintAvailable;

        public static string AutoRetreivedPhoneNumber = String.Empty;

        public static string AutoRetreivedDeviceId = String.Empty;

        public static string PdfFolder = "PayrollPDF";
    }
}
