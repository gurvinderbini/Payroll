using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.NavigationService;
using Payroll.Services;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Payroll.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public  RelayCommand LoginCommand=>new RelayCommand(Login);

        private async void Login()
        {
            try
            {

                Helper.IsFingerPrintAvailable = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync();

                //if user is already logged in
                if (Settings.IsLoggedIn)
                {
                    var contact = new Contact();
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
                if (String.IsNullOrEmpty(Helper.AutoRetreivedPhoneNumber))
                {
                    await PopupNavigation.PushAsync(new PhoneNumberRgPopUp());
                    UserDialogs.Instance.HideLoading();
                    return;
                }

                //if we retreive the contact and check whether it is verfied or not
               Contact = await ContactsService.ValidateContact(CrossDevice.Device.DeviceId, Helper.AutoRetreivedPhoneNumber);
                if (Contact != null)
                {
                    //if yes than it is navigated
                    if (Contact.IsVarified)
                    {
                        Navigate(Contact);
                    }
                    else
                    { //otherwise verfied popup will open
                        await PopupNavigation.PushAsync(new CredentialsRgPopUp(Contact));
                    }
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("You are not a registered user !");
                    DependencyService.Get<ICloseApplication>().CloseApp(); ;
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        public Contact Contact { get; set; }

        public void Navigate(Contact contact)
        {
            NavigationService.NavigateTo(ViewModelLocator.Home, contact);
        }
    }
}
