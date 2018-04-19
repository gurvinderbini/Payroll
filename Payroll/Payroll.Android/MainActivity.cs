using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;

namespace Payroll.Droid
{
    [Activity(Label = "Payroll", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
           UserDialogs.Init(this);
           // Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            global::Xamarin.Forms.Forms.Init(this, bundle);

            GetPhoneNumber();
            LoadApplication(new App());
        }


        public void GetPhoneNumber()
        {
            try
            {
                TelephonyManager mTelephonyMgr = (TelephonyManager)GetSystemService(TelephonyService);
                Settings.Contact = mTelephonyMgr.Line1Number;
            }
            catch (Exception e)
            {
              
            }
          
        }
    }
}

