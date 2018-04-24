using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Model;
using Payroll.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaySlipDetail : ContentPage
	{
	    private readonly PaySlipDetailViewModel _viewModel = App.Locator.PaySlipDetailViewModel;
		public PaySlipDetail ()
		{
			InitializeComponent ();
		    BindingContext = _viewModel;
            NavigationPage.SetHasNavigationBar(this,false);
            _viewModel.Initilize();
		}

	    private void WebView_OnNavigated(object sender, WebNavigatedEventArgs e)
	    {
	        if (e.Result == WebNavigationResult.Success)
	        {
                UserDialogs.Instance.HideLoading();
	        }
	    }
	}
}