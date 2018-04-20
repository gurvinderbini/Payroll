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
        public readonly HomeViewModel _viewModel = App.Locator.HomeViewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }
        public Home(Contact contact)
        {
            InitializeComponent();

            Settings.IsLoggedIn = true;

            BindingContext = _viewModel;
            _viewModel.Contact = contact;


            try
            {
                if (Helper.AuthenticationNeeded)
                {
                    _viewModel.LayoutVisibility = false;

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
                    _viewModel.LayoutVisibility = true;
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
                var dialogConfig = new AuthenticationRequestConfiguration("Put your finger!")
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
                    _viewModel.LayoutVisibility = true;
                }
                else
                {
                    await DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
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