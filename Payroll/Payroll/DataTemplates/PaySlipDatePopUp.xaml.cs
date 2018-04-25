using Acr.UserDialogs;

using Payroll.Extensions;
using Payroll.ViewModels;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaySlipDatePopUp : PopupPage
    {
        private PaySlipDetailViewModel _viewModel;

        public PaySlipDatePopUp(PaySlipDetailViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            MonthPicker.ItemsSource = viewModel.MonthsList;
            YearPicker.ItemsSource = viewModel.YearsList;

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            
            await PopupNavigation.PopAsync();
            UserDialogs.Instance.ShowLoading("Generating Payslip ! Please wait");
            var url = "https://payroll.erpcrebit.com/Content/ClientAttach/PayHistory/payroll/3541/2018/3/PaySlip_3541_2018_3.pdf";
            _viewModel.PdfDocumentStream = await Task.Run(() => url.ConvertToStream());

            UserDialogs.Instance.HideLoading();
          
        }

        private void MonthPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedMonth = Convert.ToString(MonthPicker.SelectedItem);
        }

        private void YearPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedYear = Convert.ToString(MonthPicker.SelectedItem);
        }
    }
}