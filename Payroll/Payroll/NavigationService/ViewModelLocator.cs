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
        public const string PaySlipsList = "PaySlipsList";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<PaySlipsListViewModel>();
        }

        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public PaySlipsListViewModel PaySlipsListViewModel => ServiceLocator.Current.GetInstance<PaySlipsListViewModel>();

        
    }
}
