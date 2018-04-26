using Acr.UserDialogs;

using Payroll.Extensions;
using Payroll.ViewModels;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Payroll.Interfaces;
using Payroll.Services;
using Xamarin.Forms;
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
            _viewModel.SelectedMonth = viewModel.MonthsList[0];
            _viewModel.SelectedYear = viewModel.YearsList[0];

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

            await PopupNavigation.PopAsync();
            try
            {
                _viewModel.LoadingVisibilty = true;
                // UserDialogs.Instance.ShowLoading("Generating Payslip ! Please wait");
                var result = await new PaySlipService().GetPaySlip(_viewModel.SelectedMonthNumber, Convert.ToInt32(_viewModel.SelectedYear), Helpers.Helper.AutoRetreivedDeviceId);
                if (result.Success == "true")
                {
                    var filename = $"{_viewModel.SelectedMonth}_{_viewModel.SelectedYear}_payslip.pdf";

                    var bytes = DependencyService.Get<IFileOperations>().ReadPDF(filename);
                    if (bytes != null)
                    {
                        _viewModel.PdfDocumentStream =  new MemoryStream(bytes);
                    }
                    else
                    {
                        var url = result.Payslip;
                        _viewModel.PdfDocumentStream = await Task.Run(() => url.ConvertToStream());

                        // _viewModel.WebviewSource = url;
                        //   Device.OpenUri(new Uri(url));
                    }
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(result.Message);
                }
                _viewModel.LoadingVisibilty = false;
                //   UserDialogs.Instance.HideLoading();
            }
            catch (Exception exception)
            {
                await UserDialogs.Instance.AlertAsync("Sorry payslip cannot be created");
                _viewModel.LoadingVisibilty = false;

                //  UserDialogs.Instance.HideLoading();
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

        private void Close_Tapped(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}