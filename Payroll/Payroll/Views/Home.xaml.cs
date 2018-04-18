using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        Settings.DeviceToken=String.Empty;
	        Navigation.PushAsync(new MainPage());
	    }
	}
}