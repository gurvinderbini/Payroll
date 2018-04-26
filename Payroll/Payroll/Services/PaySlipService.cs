using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payroll.Model;

namespace Payroll.Services
{
    public class PaySlipService : ApiBaseService
    {
        public async Task<PaySlipsBO> GetPaySlip(int month, int year, string deviceToken)
        {
            try
            {
                var endpoint = String.Format(GetPaySlipPDf, month, year, deviceToken);
                var payslip = await HttpClientBase.Get<PaySlipsBO>(endpoint);
                return payslip;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
