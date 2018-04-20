using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Interfaces;
using Payroll.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnterPinPopUp : PopupPage
	{
	    private Home Home;

        public EnterPinPopUp (Home home)
		{
			InitializeComponent();
		    Home = home;
		}

	    private void PinEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        string _text = PinEntry.Text;      //Get Current Text
	        if (_text.Length > 4)       //If it is more than your character restriction
	        {
	            _text = _text.Remove(_text.Length - 1);  // Remove Last character
	            PinEntry.Text = _text;        //Set the Old value
	        }
        }

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	        if (PinEntry.Text == Settings.DeviceSecurityPin)
	        {
	            Home._viewModel.LayoutVisibility = true;
	            PopupNavigation.PopAsync();

            }
            else
	        {
	          var result=await  UserDialogs.Instance.ConfirmAsync("Invalid Pin", null, "Close App", "Retry");
	            if (result)
	            {
                    DependencyService.Get<ICloseApplication>().CloseApp();;
	            }
	        }
        }
	}
}