using System;
using Payroll.Model;
using Payroll.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
	    private readonly HomeViewModel _viewModel = App.Locator.HomeViewModel;
		public Home ()
		{
			InitializeComponent ();
		    BindingContext = _viewModel;
		}
	    public Home(Contact contact)
	    {
	        InitializeComponent();
	        BindingContext = _viewModel;
	        _viewModel.Contact = contact;
	    }

        private void Button_OnClicked(object sender, EventArgs e)
	    {
	        Settings.DeviceToken=String.Empty;
	        Navigation.PushAsync(new MainPage());
	    }
	}
}