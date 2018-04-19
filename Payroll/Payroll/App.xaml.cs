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
        private readonly NavigationService.NavigationService _navigationService;

        #region Locator
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        #endregion

        public App()
        {
            InitializeComponent();
            _navigationService = new NavigationService.NavigationService();
            _navigationService.Configure(ViewModelLocator.Home, typeof(Home));
            _navigationService.Configure(ViewModelLocator.MainPage, typeof(MainPage));

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                SimpleIoc.Default.Register<INavigationService>(() => _navigationService);

            var firstPage = new NavigationPage(new MainPage());
            _navigationService.Initialize(firstPage);
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
