using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Payroll.Helpers;
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

        private Contact _contact;

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                RaisePropertyChanged();
            }
        }

        private async void ClearAuthentication()
        {
            Helper.AuthenticationNeeded = true;

            Settings.IsLoggedIn = false;
            Settings.EntryID =0;
            Settings.Name = String.Empty;
            Settings.Email = String.Empty;
            Settings.PhoneNumber = String.Empty;
            Settings.AccountNumber = String.Empty;
            Settings.DeviceID = String.Empty;
            Settings.IsVarified = false;

            Contact.IsVarified = false;
            await new ContactsService().UpdateContact(Contact);
            NavigationService.GoBack();
        }
    }
}
