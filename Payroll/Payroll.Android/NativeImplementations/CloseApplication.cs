using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Payroll.Droid.NativeImplementations;
using Payroll.Interfaces;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace Payroll.Droid.NativeImplementations
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            //var activity = (Activity)Forms.Context;
            //activity.FinishAffinity();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}