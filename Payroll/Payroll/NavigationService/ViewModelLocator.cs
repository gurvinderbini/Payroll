using Payroll.ViewModels;
using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

namespace Payroll.NavigationService
{
    public class ViewModelLocator
    {
        public const string MainPage = "MainPage";
        public const string Home = "Home";
        public const string PaySlipsList = "PaySlipsList";
        public const string PaySlipsDetail = "PaySlipsDetail";
        public const string Profile = "Profile";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<PaySlipsListViewModel>();
            SimpleIoc.Default.Register<PaySlipDetailViewModel>();
            SimpleIoc.Default.Register<ProfileViewModel>();
        }

        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public PaySlipsListViewModel PaySlipsListViewModel => ServiceLocator.Current.GetInstance<PaySlipsListViewModel>();
        public PaySlipDetailViewModel PaySlipDetailViewModel => ServiceLocator.Current.GetInstance<PaySlipDetailViewModel>();
        public ProfileViewModel ProfileViewModel => ServiceLocator.Current.GetInstance<ProfileViewModel>();
    }
}
