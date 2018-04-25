using Payroll.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
	    private readonly ProfileViewModel _viewModel = App.Locator.ProfileViewModel;
		public Profile ()
		{
			InitializeComponent ();
		    BindingContext = _viewModel;
            NavigationPage.SetHasNavigationBar(this,false);

		}
	}
}