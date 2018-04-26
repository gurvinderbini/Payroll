namespace Payroll.Services
{
    public class ApiBaseService
    {
        protected static HttpClientBase HttpClientBase = new HttpClientBase();


        // "https://infiniti.erpcrebit.com/json/payrollapi/registerdevice?phonenumber=jhj&Emailaddress=sdfsh&DeviceId=75375273"

        public static readonly string BaseUrl = "https://abc.erpcrebit.com/";//"https://infiniti.erpcrebit.com/";// ;

        public static readonly string Validate ="json/payrollapi/registerdevice?phonenumber={0}&Emailaddress={1}&DeviceId={2}";

        public static readonly string GetPaySlipPDf = "json/payrollapi/getpayslip?pmonth={0}&pyear={1}&DeviceId={2}";
        public static readonly string GetContacts = "api/Device/GetContacts?DeviceId={0}&PhoneNumber={1}";

        public static readonly string InsertContact = "api/Device/{0}";
    }
}
