using Android.App;
using Android.Content;
using Android.Telephony;
using Payroll.Droid.NativeImplementations;
using Payroll.Helpers;
using Payroll.Interfaces;
using System;
[assembly: Xamarin.Forms.Dependency(typeof(RegisterPhoneDetails))]

namespace Payroll.Droid.NativeImplementations
{
    public class RegisterPhoneDetails : IRegisterPhoneDetails
    {
        public void RegisterDetails()
        {
            try
            {
                var mTelephonyMgr = (TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
                //if (mTelephonyMgr.Line1Number.Equals("15555215554")) return;
                Helper.AutoRetreivedPhoneNumber = mTelephonyMgr.Line1Number.Equals("15555215554")?String.Empty : mTelephonyMgr.Line1Number;
                Helper.AutoRetreivedDeviceId = mTelephonyMgr.Imei.Equals("000000000000000") ? "356479087408700": mTelephonyMgr.Imei;
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}