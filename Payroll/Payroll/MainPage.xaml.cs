using Acr.UserDialogs;

using Payroll.Interfaces;
using Payroll.ViewModels;

using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;

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
            }
            catch (Exception e)
            {
                
            }

        }
    }
}
