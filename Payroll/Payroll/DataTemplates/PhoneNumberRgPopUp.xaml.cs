using Acr.UserDialogs;

using Payroll.Model;
using Payroll.Helpers;
using Payroll.Services;
using Payroll.ViewModels;
using Payroll.Interfaces;
using Payroll.NavigationService;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneNumberRgPopUp : PopupPage
    {
        //public ContactBO Contact;

        public UserDeviceBO UserDevice;
        public PhoneNumberRgPopUp()
        {
            InitializeComponent();

            PhoneNumberEntry.Text = "8053090300";
            EmailEntry.Text = "femi.onashile@ebsrcm.com";
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Authenticating");
            try
            {
                UserDevice = await new ValidationService().ValidateUser(Helper.AutoRetreivedDeviceId, PhoneNumberEntry.Text,EmailEntry.Text);
                if (UserDevice == null)
                {
                    await UserDialogs.Instance.AlertAsync("Sorry something went wrong!");
                    UserDialogs.Instance.HideLoading();
                    return;
                }

                if (UserDevice.Success=="true")
                {
                    await PopupNavigation.PopAsync();
                    BaseViewModel.NavigationService.NavigateTo(ViewModelLocator.Home, UserDevice);
                }
                else
                {
                    var result = await UserDialogs.Instance.ConfirmAsync(UserDevice.Message, "", "Close App", "Retry");
                    if (result)
                    {
                        DependencyService.Get<ICloseApplication>().CloseApp();
                    }
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }

        }

        //private async void EmailClick(object sender, EventArgs e)
        //{
        //    if (Contact.Email.ToLower(CultureInfo.CurrentCulture) == EmailEntry.Text.ToLower(CultureInfo.CurrentCulture))
        //    {
        //        Navigation.PopAsync();
        //       }
        //    else
        //    {
        //        var result = await UserDialogs.Instance.ConfirmAsync("Mobile number is not valid !", "", "Close App", "Retry");
        //        if (result)
        //        {
        //            DependencyService.Get<ICloseApplication>().CloseApp();
        //        }
        //       }

        //   }
    }
}