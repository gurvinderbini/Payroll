﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.NavigationService;
using Payroll.Services;
using Payroll.ViewModels;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneNumberRgPopUp : PopupPage
    {
        public Contact Contact;

        public PhoneNumberRgPopUp()
        {
            InitializeComponent();

            //PhoneNumberEntry.Text = "8154617032";
            //EmailEntry.Text = "Charles.onwumere@infinitisys.com";
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Authenticating");
            try
            {
                Contact = await new ContactsService().ValidateContact(CrossDevice.Device.DeviceId, PhoneNumberEntry.Text);
                if (Contact != null && !String.IsNullOrEmpty(Contact.PhoneNumber))
                {
                    if (string.Compare(Contact.Email.Trim(), EmailEntry.Text.Trim(),true) == 0)
                    {
                        await PopupNavigation.PopAsync();
                        BaseViewModel.NavigationService.NavigateTo(ViewModelLocator.Home, Contact);
                    }
                    else
                    {
                        var result = await UserDialogs.Instance.ConfirmAsync("Email is not valid !", "", "Close App", "Retry");
                        if (result)
                        {
                            DependencyService.Get<ICloseApplication>().CloseApp();
                        }
                    }
                }
                else
                {
                    var result = await UserDialogs.Instance.ConfirmAsync("Mobile number is not valid !", "", "Close App", "Retry");
                    if (result)
                    {
                        DependencyService.Get<ICloseApplication>().CloseApp();
                    }
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception exception)
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