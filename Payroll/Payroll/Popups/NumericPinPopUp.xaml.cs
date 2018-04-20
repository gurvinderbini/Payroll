using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NumericPinPopUp : PopupPage
	{
	    private Home Home;

        public NumericPinPopUp (Home home)
		{
			InitializeComponent ();
		    Home = home;
		}

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        if (PinEntry.Text != Pin2Entry.Text)
	        {
	            UserDialogs.Instance.Alert("Both pins dont match");
                return;
            }
	        Settings.DeviceSecurityPin = PinEntry.Text;
	        Home.ViewModel.LayoutVisibility = true;
	        PopupNavigation.PopAsync();
	    }

	    private void PinEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        string _text = PinEntry.Text;   
	        if (_text.Length > 4)      
	        {
	            _text = _text.Remove(_text.Length - 1);  
	            PinEntry.Text = _text;        
	        }
        }

	    private void Pin2Entry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        string _text = Pin2Entry.Text;      
	        if (_text.Length > 4)      
	        {
	            _text = _text.Remove(_text.Length - 1);  
	            Pin2Entry.Text = _text;      
	        }
        }
	}
}