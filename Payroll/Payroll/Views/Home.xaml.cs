using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Model;
using Payroll.ViewModels;
using Plugin.Fingerprint.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public readonly HomeViewModel ViewModel = App.Locator.HomeViewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        public Home(Contact contact)
        {
            InitializeComponent();
            BindingContext = ViewModel;

            Settings.IsLoggedIn = true;
            Settings.EntryID = contact.EntryID;
            Settings.Name = contact.Name;
            Settings.Email = contact.Email;
            Settings.PhoneNumber = contact.PhoneNumber;
            Settings.AccountNumber = contact.AccountNumber;
            Settings.DeviceID = contact.DeviceID;
            Settings.IsVarified = contact.IsVarified;

            ViewModel.Contact = contact;


            try
            {
                if (Helper.AuthenticationNeeded)
                {
                    ViewModel.LayoutVisibility = false;

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
                    ViewModel.LayoutVisibility = true;
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
                    CancelTitle = "Cancel",
                    FallbackTitle = null,
                    UseDialog = true,
                    AllowAlternativeAuthentication = true
                };

                var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync
                    (dialogConfig, new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);

                if (result.Authenticated)
                {
                    ViewModel.LayoutVisibility = true;
                }
                else
                {
                    await DisplayAlert("Cannot Authenticate with Fingerprint, try pin instead", result.ErrorMessage, "Ok");
                    PinAuthentication();
                }
            }
            catch (Exception e)
            {
                
            }
          
        }

        private async void PinAuthentication()
        {
            try
            {
                if (String.IsNullOrEmpty(Settings.DeviceSecurityPin))
                {
                    await PopupNavigation.PushAsync(new NumericPinPopUp(this));
                }
                else
                {
                    await PopupNavigation.PushAsync(new EnterPinPopUp(this));

                }
            }
            catch (Exception e)
            {
               
            }

         
        }

       
    }
}