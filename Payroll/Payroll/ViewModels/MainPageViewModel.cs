using Acr.UserDialogs;

using Rg.Plugins.Popup.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Payroll.Model;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.DataTemplates;
using Payroll.NavigationService;

using System;
using Xamarin.Forms;

namespace Payroll.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region CTOR
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Properties
        public ContactBO Contact { get; set; }
        #endregion

        #region Commands
        public RelayCommand LoginCommand => new RelayCommand(Login);
        #endregion

        #region Events
        private async void Login()
        {
            try
            {

                Helper.IsFingerPrintAvailable = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync();

                //if user is already logged in
                if (Settings.IsLoggedIn)
                {
                    var contact = new ContactBO();
                    Settings.IsLoggedIn = true;
                    contact.EntryID = Settings.EntryID;
                    contact.Name = Settings.Name;
                    contact.Email = Settings.Email;
                    contact.PhoneNumber = Settings.PhoneNumber;
                    contact.AccountNumber = Settings.AccountNumber;
                    contact.DeviceID = Settings.DeviceID;
                    contact.IsVarified = Settings.IsVarified;
                    Navigate(contact);
                    return;
                }

                UserDialogs.Instance.ShowLoading("Authenticating");
                //if we cannot retreive the contact

                await PopupNavigation.PushAsync(new PhoneNumberRgPopUp());
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public void Navigate(ContactBO contact)
        {
            NavigationService.NavigateTo(ViewModelLocator.Home, contact);
        }
        #endregion


        ////if we retreive the contact and check whether it is verfied or not
        //Contact = await ContactsService.ValidateContact(Helper.AutoRetreivedDeviceId, Helper.AutoRetreivedPhoneNumber,"");
        //    if (Contact != null)
        //{
        //    //if yes than it is navigated
        //    if (Contact.IsVarified)
        //    {
        //        Navigate(Contact);
        //    }
        //    else
        //    { //otherwise verfied popup will open
        //        await PopupNavigation.PushAsync(new CredentialsRgPopUp(Contact));
        //    }
        //}
        //else
        //{
        //    await UserDialogs.Instance.AlertAsync("You are not a registered user !");
        //    DependencyService.Get<ICloseApplication>().CloseApp(); ;
        //}
    }
}
