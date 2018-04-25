using Payroll.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaySlipsList : ContentPage
	{
		public PaySlipsList ()
		{
			InitializeComponent ();
           
		}

	    private void PayslipsListview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        if(e.SelectedItem==null)return;
	        var paySlip = e.SelectedItem as PaySlipsBO;
	        Navigation.PushAsync(new PaySlipDetail());
	    }
	}
}