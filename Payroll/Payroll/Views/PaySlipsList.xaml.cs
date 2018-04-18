using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            PayslipsListview.ItemsSource=new List<PaySlipsBO>()
            {
                new PaySlipsBO(){Month = "January",Year = "2018",TotalPay = "20,000",Deductions = "2,500",NetPay = "17,500"},
		        new PaySlipsBO(){Month = "Febuary",Year = "2018",TotalPay = "20,000",Deductions = "2,500",NetPay = "17,500"},
                new PaySlipsBO(){Month = "March",Year = "2018",TotalPay = "20,000",Deductions = "2,500",NetPay = "17,500"},
                new PaySlipsBO(){Month = "April",Year = "2018",TotalPay = "20,000",Deductions = "2,500",NetPay = "17,500"}

            };
		}

	    private void PayslipsListview_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        if(e.SelectedItem==null)return;
	        var paySlip = e.SelectedItem as PaySlipsBO;
	        Navigation.PushAsync(new PaySlipDetail(paySlip));
	    }
	}
}