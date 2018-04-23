using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Interfaces;
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
            NavigationPage.SetHasNavigationBar(this, false);
            ViewModel.Initilize(contact);
        }
    }
}