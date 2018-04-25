using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.NavigationService;
using Payroll.Services;
using Plugin.Fingerprint.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Payroll.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        #region CTOR
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
        #endregion

        #region Observable Properties

        private ContactBO _contact;

        public ContactBO Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                RaisePropertyChanged();
            }
        }

        private UserDeviceBO _userDevice;

        public UserDeviceBO UserDevice
        {
            get => _userDevice;
            set
            {
                _userDevice = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand ClearAuthenticationCommand => new RelayCommand(ClearAuthentication);
        public RelayCommand CloseCommand => new RelayCommand(Close);
        public RelayCommand PaySlipsCommand => new RelayCommand(PaySlips);
        public RelayCommand GoToProfileCommand => new RelayCommand(GoToProfile);
        #endregion

        #region Events
        public void Initilize(ContactBO contact)
        {
            Settings.IsLoggedIn = true;
            Settings.EntryID = contact.EntryID;
            Settings.Name = contact.Name;
            Settings.Email = contact.Email;
            Settings.PhoneNumber = contact.PhoneNumber;
            Settings.AccountNumber = contact.AccountNumber;
            Settings.DeviceID = contact.DeviceID;
            Settings.IsVarified = contact.IsVarified;

            Contact = contact;


            try
            {
                if (Helper.AuthenticationNeeded)
                {
                    LayoutVisibility = false;

                    if (Helper.IsFingerPrintAvailable)
                    {
                        FingerPrintAuthentication();
                    }
                    else
                    {
                        PinAuthentication();
                    }

                    Helper.AuthenticationNeeded = false;
                }
                else
                {
                    LayoutVisibility = true;
                }

            }
            catch (Exception e)
            {

            }
        }

        public void Initilize(UserDeviceBO userDeviceBo)
        {
            Settings.IsLoggedIn = true;
            Settings.Name = userDeviceBo.UserDevice[0].EmployeeName;
            //Settings.EntryID = contact.EntryID;
            //Settings.Name = contact.Name;
            //Settings.Email = contact.Email;
            //Settings.PhoneNumber = contact.PhoneNumber;
            //Settings.AccountNumber = contact.AccountNumber;
            //Settings.DeviceID = contact.DeviceID;
            //Settings.IsVarified = contact.IsVarified;

            UserDevice = userDeviceBo;


            try
            {
                if (Helper.AuthenticationNeeded)
                {
                    LayoutVisibility = false;

                    if (Helper.IsFingerPrintAvailable)
                    {
                        FingerPrintAuthentication();
                    }
                    else
                    {
                        PinAuthentication();
                    }

                    Helper.AuthenticationNeeded = false;
                }
                else
                {
                    LayoutVisibility = true;
                }

            }
            catch (Exception e)
            {

            }
        }

        private async void FingerPrintAuthentication()
        {
            try
            {
                var dialogConfig = new AuthenticationRequestConfiguration("Place your fingerprint to authenticate")
                {
                    CancelTitle = null,
                    FallbackTitle = "Use Pin",
                    UseDialog = true,
                    AllowAlternativeAuthentication = true
                };

                var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                    (dialogConfig, new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);


                if (result.Authenticated)
                {
                    LayoutVisibility = true;
                }
                else if (result.Status == FingerprintAuthenticationResultStatus.Canceled)
                {
                    DependencyService.Get<ICloseApplication>().CloseApp();
                }
                else
                {
                    PinAuthentication();
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private async void PinAuthentication()
        {
            try
            {
                if (String.IsNullOrEmpty(Settings.DeviceSecurityPin))
                {
                    await PopupNavigation.PushAsync(new SetNumericPinPopUp(this));
                }
                else
                {
                    await PopupNavigation.PushAsync(new EnterPinPopUp(this));
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private void PaySlips()
        {
            NavigationService.NavigateTo(ViewModelLocator.PaySlipsDetail);
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
            Settings.Name = String.Empty;
            //Settings.EntryID = 0;
            //Settings.Name = String.Empty;
            //Settings.Email = String.Empty;
            //Settings.PhoneNumber = String.Empty;
            //Settings.AccountNumber = String.Empty;
            //Settings.DeviceID = String.Empty;
            //Settings.IsVarified = false;

            //Contact.IsVarified = false;
            await new ContactsService().UpdateContact(Contact);
            NavigationService.GoBack();
        }

        private void GoToProfile()
        {
            NavigationService.NavigateTo(ViewModelLocator.Profile);
        }

        #endregion
    }
}
