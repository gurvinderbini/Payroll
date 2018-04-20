using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.NavigationService;
using Payroll.Services;
using Payroll.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CredentialsRgPopUp : PopupPage
    {
        private Contact _contact;
        public CredentialsRgPopUp()
        {
            InitializeComponent();
           
        }


        public CredentialsRgPopUp(Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            NameLabel.Text = contact.Name;
            EmailLabel.Text = contact.Email;
            ContactLabel.Text = contact.PhoneNumber;
        }

        private async void CloseApp(object sender, EventArgs e)
        {
           var result=await UserDialogs.Instance.ConfirmAsync("Do you want to Quit");
            if (result)
            {
                DependencyService.Get<ICloseApplication>().CloseApp(); 
            }
        }

        private async void NavigatePage(object sender, EventArgs e)
        {
            _contact.IsVarified = true;
            var result = await new ContactsService().UpdateContact(_contact);
            await PopupNavigation.PopAsync();
            BaseViewModel.NavigationService.NavigateTo(ViewModelLocator.Home, _contact);

        }
    }
}