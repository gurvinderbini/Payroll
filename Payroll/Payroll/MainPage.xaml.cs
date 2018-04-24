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
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
            var result = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (result == PermissionStatus.Denied)
            {
                var re = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

            }

        }
    }
}
