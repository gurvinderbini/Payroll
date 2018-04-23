using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;

namespace Payroll.ViewModels
{
    public class PaySlipDetailViewModel:BaseViewModel
    {
        #region CTOR
        public PaySlipDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion
        #region Commands
       // public RelayCommand BackCommand => new RelayCommand(Back);
        #endregion

        #region Events

        private void Back()
        {
            NavigationService.GoBack();
        }
        #endregion
    }
}
