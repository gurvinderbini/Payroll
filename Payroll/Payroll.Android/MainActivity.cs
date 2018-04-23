﻿using Acr.UserDialogs;

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
using FormsPinView.Droid;
using Java.Lang;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Exception = System.Exception;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Permission = Plugin.Permissions.Abstractions.Permission;
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
            PinItemViewRenderer.Init();
            GetPhoneNumber();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public  void GetPhoneNumber()
        {
            try
            {
                TelephonyManager mTelephonyMgr = (TelephonyManager)GetSystemService(TelephonyService);
                if(mTelephonyMgr.Line1Number.Equals("15555215554"))return;
                Helpers.Helper.AutoRetreivedPhoneNumber = mTelephonyMgr.Line1Number;
            }
            catch (Exception e)
            {
              
            }
          
        }
    }
    
}

