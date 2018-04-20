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
              
                Helper.IsFingerPrintAvailable=await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync();

                //if user is already logged in
                if (Settings.IsLoggedIn)
                {
                    _viewModel.Navigate(new Contact());
                    return;
                }

                UserDialogs.Instance.ShowLoading("Authenticating");
                //if we cannot retreive the contact
                if (String.IsNullOrEmpty(Settings.Contact))
                {
                  await  PopupNavigation.PushAsync(new PhoneNumberRgPopUp());
                    UserDialogs.Instance.HideLoading();
                    return;
                }

                //if we retreive the contact and check whether it is verfied or not
                _viewModel.Contact = await new ContactsService().ValidateContact(CrossDevice.Device.DeviceId, Settings.Contact);
                if (_viewModel.Contact != null)
                {
                    //if yes than it is navigated
                    if (_viewModel.Contact.IsVarified)
                    {
                      _viewModel.Navigate(_viewModel.Contact);
                    }
                    else
                    { //otherwise verfied popup will open
                        await PopupNavigation.PushAsync(new CredentialsRgPopUp(_viewModel.Contact));
                    }
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("You are not a registered user !");
                    DependencyService.Get<ICloseApplication>().CloseApp(); ;
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception e)
            {
                UserDialogs.Instance.HideLoading();
            }

        }
    }
}
