using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Payroll.NavigationService;
using Payroll.Views;
using Plugin.DeviceInfo;
using Plugin.Messaging;
using Xamarin.Forms;


namespace Payroll
{
    public partial class App : Application
    {
        #region Locator
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        #endregion

        public App()
        {
            InitializeComponent();
            var navigationService = new NavigationService.NavigationService();
            navigationService.Configure(ViewModelLocator.Home, typeof(Home));
            navigationService.Configure(ViewModelLocator.MainPage, typeof(MainPage));
            navigationService.Configure(ViewModelLocator.PaySlipsList, typeof(PaySlipsList));
            navigationService.Configure(ViewModelLocator.PaySlipsDetail, typeof(PaySlipDetail));
            navigationService.Configure(ViewModelLocator.Profile, typeof(Profile));

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            var firstPage = new NavigationPage(new MainPage());
            navigationService.Initialize(firstPage);
            MainPage = firstPage;
        }

       

        protected override void OnStart()
        {
       
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
