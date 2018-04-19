using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
using Plugin.Messaging;
using Rg.Plugins.Popup.Services;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace Payroll
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel = App.Locator.MainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
           
            //Layout.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            //Layout.PopupView.AcceptButtonText = "Yes, Its me !";
            //Layout.PopupView.AcceptCommand = new Command((async () =>
            //{
            //    //_viewModel.Contact.IsVarified = true;
            //    //var result = await new ContactsService().UpdateContact(_viewModel.Contact);

            //}));
            //Layout.PopupView.DeclineCommand = new Command((() =>
            //{
            //    DependencyService.Get<ICloseApplication>().CloseApp(); 
            //}));
            //Layout.PopupView.DeclineButtonText = "No, Thats not me !";
            //Layout.PopupView.HeaderTitle = "Your Details";
           
            NavigationPage.SetHasNavigationBar(this, false);
        }

       
     
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                _viewModel.LayoutVisibility = false;
                UserDialogs.Instance.ShowLoading("Authenticating");
                //Settings.Contact = "9023309984";
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
               
            }

        }
    }
}
