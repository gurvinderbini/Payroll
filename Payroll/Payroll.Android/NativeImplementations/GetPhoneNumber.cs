using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Payroll.Droid.NativeImplementations;
using Payroll.Interfaces;
[assembly: Xamarin.Forms.Dependency(typeof(GetPhoneNumber))]

namespace Payroll.Droid.NativeImplementations
{
    public class GetPhoneNumber:IGetPhoneNumber
    {
        public string GetNumber()
        {
            try
            {
                var mTelephonyMgr = (TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
                if (mTelephonyMgr.Line1Number.Equals("15555215554")) return "";
                Helpers.Helper.AutoRetreivedPhoneNumber = mTelephonyMgr.Line1Number;
                return mTelephonyMgr.Line1Number;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}