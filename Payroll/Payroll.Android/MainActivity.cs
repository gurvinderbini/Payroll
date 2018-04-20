using Acr.UserDialogs;

using Android.OS;
using Android.App;
using Android.Content.PM;

using Android.Telephony;

using Plugin.Fingerprint;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Provider;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Widget;
using Java.Lang;
using Xamarin.Forms;
using Exception = System.Exception;
using Permission = Android.Content.PM.Permission;
using String = System.String;

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
            CrossFingerprint.SetCurrentActivityResolver(() => this);

            GetPhoneNumber();
            LoadApplication(new App());
        }

        public void GetPhoneNumber()
        {
            try
            {
                TelephonyManager mTelephonyMgr = (TelephonyManager)GetSystemService(TelephonyService);
               Payroll.Settings.Contact = mTelephonyMgr.Line1Number;
            }
            catch (Exception e)
            {
              
            }
          
        }
    }
    
}

