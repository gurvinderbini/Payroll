using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Extensions;
using Payroll.Interfaces;
using Payroll.ViewModels;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //var stream = pdfViewerControl.SaveDocument();
            //var filename = _viewModel.SelectedMonth + _viewModel.SelectedYear + "PaySlip.pdf";
            //var fileOperations = DependencyService.Get<IFileOperations>();
            //var result = fileOperations.SavePDF(filename, stream.GetBytes());
            //if (result)
            //{
            //    await UserDialogs.Instance.AlertAsync("Pay slip saved in Documents");
            //}
            //else
            //{
            //    var perResult = await UserDialogs.Instance.ConfirmAsync("Do not have required permissions to sae payslip", okText: "Allow Permissions", cancelText: "cancel");
            //    if (perResult)
            //    {
            //        var result1 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            //        if (result1 == PermissionStatus.Denied)
            //        {
            //            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            //        }
            //    }
            //}
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