using Acr.UserDialogs;

using Payroll.Model;
using Payroll.Helpers;
using Payroll.Services;
using Payroll.Interfaces;
using Payroll.ViewModels;
using Payroll.NavigationService;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhoneNumberRgPopUp : PopupPage
	{
	    public Contact Contact;

		public PhoneNumberRgPopUp ()
		{
			InitializeComponent ();
		}

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
            UserDialogs.Instance.ShowLoading("Authenticating");
	        try
	        {
	            Contact = await new ContactsService().ValidateContact(Helper.AutoRetreivedDeviceId, PhoneNumberEntry.Text);
	            if (Contact != null)
	            {
	                if (Contact.Email.ToLower(CultureInfo.CurrentCulture) == EmailEntry.Text.ToLower(CultureInfo.CurrentCulture))
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
            catch (Exception)
	        {
	            UserDialogs.Instance.HideLoading();
            }
	    }
	}
}