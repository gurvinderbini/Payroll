using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll.Views;
using Plugin.DeviceInfo;
using Plugin.Messaging;
using Xamarin.Forms;


namespace Payroll
{
    public partial class App : Application
    {
       

        public App()
        {
          
            InitializeComponent();

        }

       

        protected override void OnStart()
        {
         var id=   CrossDevice.Device.DeviceId;
         var x=   CrossDevice.Network.CellularNetworkCarrier;
            if (!String.IsNullOrEmpty(Settings.DeviceToken))
            {
                MainPage = new NavigationPage(new Home()) { BarBackgroundColor = Color.MediumBlue };
            }
            else
            {
                MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.MediumBlue };
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
