using Acr.UserDialogs;

using Payroll.Extensions;
using Payroll.ViewModels;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Threading.Tasks;
using Payroll.Services;
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
            try
            {
                UserDialogs.Instance.ShowLoading("Generating Payslip ! Please wait");
                var result = await new PaySlipService().GetPaySlip(_viewModel.SelectedMonthNumber, Convert.ToInt32(_viewModel.SelectedYear), Helpers.Helper.AutoRetreivedDeviceId);
                if (result.Success == "true")
                {
                    var url = result.Payslip;
                    _viewModel.PdfDocumentStream = await Task.Run(() => url.ConvertToStream());
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(result.Message);
                }

                UserDialogs.Instance.HideLoading();
            }
            catch (Exception exception)
            {
              await  UserDialogs.Instance.AlertAsync("Sorry something went wrong");
                UserDialogs.Instance.HideLoading();
            }
            

        }

        private void MonthPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedMonth = Convert.ToString(MonthPicker.SelectedItem);
        }

        private void YearPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedYear = Convert.ToString(YearPicker.SelectedItem);
        }
    }
}