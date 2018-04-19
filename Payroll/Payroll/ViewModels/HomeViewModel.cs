using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;

namespace Payroll.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
