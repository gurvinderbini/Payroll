using System;
using Acr.UserDialogs;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Telephony;
using Android.Util;
using Plugin.Fingerprint;

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

        protected override void OnStart()
        {
            base.OnStart();
            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadPhoneState) == (int)Permission.Granted)
            //{
            //    // We have permission, go ahead and use the camera.
            //}
            //else
            //{
            //    // Camera permission is not granted. If necessary display rationale & request.
            //    if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReadPhoneState))
            //    {
            //        // Provide an additional rationale to the user if the permission was not granted
            //        // and the user would benefit from additional context for the use of the permission.
            //        // For example if the user has previously denied the permission.
            //      //  Log.Info(TAG, "Displaying camera permission rationale to provide additional context.");

            //        var requiredPermissions = new String[] { Manifest.Permission.ReadPhoneState };
            //        Snackbar.Make(layout,
            //                Resource.String.abc_action_bar_home_description,
            //                Snackbar.LengthIndefinite)
            //            .SetAction(Resource.String.ok,
            //                new Action<View>(delegate (View obj) {
            //                        ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_LOCATION);
            //                    }
            //                )
            //            ).Show();
            //    }
            //    else
            //    {
            //      //  ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, REQUEST_LOCATION);
            //    }
            //}
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

