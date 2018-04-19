using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Payroll.Model;
using Payroll.Services;
using Rg.Plugins.Popup.Services;

namespace Payroll.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public RelayCommand ClearAuthenticationCommand=>new RelayCommand(ClearAuthentication);

        public Contact Contact { get; set; }

        private async void ClearAuthentication()
        {
            Contact.IsVarified = false;
            var result = await new ContactsService().UpdateContact(Contact);
            NavigationService.GoBack();
        }
    }
}
