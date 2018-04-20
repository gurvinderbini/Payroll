using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.Services;
using Payroll.ViewModels;
using Payroll.Views;
using Plugin.DeviceInfo;
using Plugin.Fingerprint.Abstractions;
using Plugin.Messaging;
using Rg.Plugins.Popup.Services;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace Payroll
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel = App.Locator.MainPageViewModel;

        //private CancellationTokenSource _cancel;

        //private bool _initialized;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            NavigationPage.SetHasNavigationBar(this, false);
        }
     
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (Settings.IsLoggedIn)
                {
                    _viewModel.Navigate(new Contact());
                    return;
                }

                _viewModel.LayoutVisibility = false;
                UserDialogs.Instance.ShowLoading("Authenticating");

                if (String.IsNullOrEmpty(Settings.Contact))
                {
                  await  PopupNavigation.PushAsync(new PhoneNumberRgPopUp());
                    UserDialogs.Instance.HideLoading();
                    return;
                }

               
                _viewModel.Contact = await new ContactsService().ValidateContact(CrossDevice.Device.DeviceId, Settings.Contact);
                if (_viewModel.Contact != null)
                {
                    if (_viewModel.Contact.IsVarified)
                    {
                      _viewModel.Navigate(_viewModel.Contact);
                    }
                    else
                    {
                        await PopupNavigation.PushAsync(new CredentialsRgPopUp(_viewModel.Contact));
                    }
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("You are not a registered user !");
                    DependencyService.Get<ICloseApplication>().CloseApp(); ;
                }
                UserDialogs.Instance.HideLoading();
                _viewModel.LayoutVisibility = true;
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
            }

        }

        //private async void OnAuthenticate(object sender, EventArgs e)
        //{
        //    await AuthenticationAsync("Put your finger!");

        //}

        //private async Task AuthenticationAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
        //{
        //    _cancel = swAutoCancel.IsToggled ? new CancellationTokenSource(TimeSpan.FromSeconds(10)) : new CancellationTokenSource();
        //    lblStatus.Text = "";

        //    var dialogConfig = new AuthenticationRequestConfiguration(reason)
        //    { // all optional
        //        CancelTitle = cancel,
        //        FallbackTitle = fallback,
        //        AllowAlternativeAuthentication = swAllowAlternative.IsToggled
        //    };

        //    // optional

        //    var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig, _cancel.Token);

        //    await SetResultAsync(result);
        //}

        //private async Task SetResultAsync(FingerprintAuthenticationResult result)
        //{
        //    if (result.Authenticated)
        //    {
        //        await DisplayAlert("FingerPrint Sample", "Success", "Ok");
        //        _viewModel.Navigate(_viewModel.Contact);
        //    }
        //    else
        //    {
        //        await DisplayAlert("FingerPrint Sample", result.ErrorMessage, "Ok");
        //    }
        //}
    }
}
