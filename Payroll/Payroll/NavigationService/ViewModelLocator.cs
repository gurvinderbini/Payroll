using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Payroll.ViewModels;

namespace Payroll.NavigationService
{
    public class ViewModelLocator
    {
        public const string MainPage = "MainPage";
        public const string Home = "Home";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
        }

        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
    }
}
