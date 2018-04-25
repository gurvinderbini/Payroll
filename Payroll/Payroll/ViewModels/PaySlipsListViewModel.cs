using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;

namespace Payroll.ViewModels
{
    public class PaySlipsListViewModel : BaseViewModel
    {
        #region CTOR
        public PaySlipsListViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        #endregion
    }
}
