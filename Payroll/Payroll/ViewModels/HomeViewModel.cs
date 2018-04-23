using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Payroll.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public RelayCommand ClearAuthenticationCommand=>new RelayCommand(ClearAuthentication);
        public RelayCommand CloseCommand=>new RelayCommand(Close);

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

        private async void Close()
        {
            var result = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to quit the app");
            if (result)
            {
                DependencyService.Get<ICloseApplication>().CloseApp();
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
