using Acr.UserDialogs;

using Payroll.Interfaces;
using Payroll.ViewModels;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;
using Payroll.Helpers;
using Payroll.Model;
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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var result = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                if (result == PermissionStatus.Denied)
                {
                    await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                    if (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage) !=
                        PermissionStatus.Granted)
                    {
                        await UserDialogs.Instance.AlertAsync("Some storage features may not work appropriately !");

                    }
                   
                }

                result = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
                if (result == PermissionStatus.Denied)
                {
                  await CrossPermissions.Current.RequestPermissionsAsync(Permission.Phone);
                    if (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone) != PermissionStatus.Granted)
                    {
                        await UserDialogs.Instance.AlertAsync("Some features may not work appropriately !");
                    }
                    else
                    {
                        DependencyService.Get<IRegisterPhoneDetails>().RegisterDetails();
                    }
                }

                Helper.IsFingerPrintAvailable = await Plugin.Fingerprint.CrossFingerprint.Current.IsAvailableAsync();

                //if user is already logged in
                if (Settings.IsLoggedIn)
                {
                    Settings.IsLoggedIn = true;
                    var userDeviceBo = new UserDeviceBO {UserDevice = new Userdevice[1]};

                    userDeviceBo.UserDevice[0]=new Userdevice(){EmployeeName = Settings.Name};
                    //contact.EntryID = Settings.EntryID;
                    //contact.Email = Settings.Email;
                    //contact.PhoneNumber = Settings.PhoneNumber;
                    //contact.AccountNumber = Settings.AccountNumber;
                    //contact.DeviceID = Settings.DeviceID;
                    //contact.IsVarified = Settings.IsVarified;
                    _viewModel.Navigate(userDeviceBo);
                
                }
            }
            catch (Exception e)
            {
                
            }

        }
    }
}
