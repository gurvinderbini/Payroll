﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Extensions;
using Payroll.Helpers;
using Payroll.Interfaces;
using Payroll.Model;
using Payroll.ViewModels;
using PCLStorage;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaySlipDetail : ContentPage
    {
        private readonly PaySlipDetailViewModel _viewModel = App.Locator.PaySlipDetailViewModel;
        public PaySlipDetail()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            NavigationPage.SetHasNavigationBar(this, false);
            _viewModel.Initilize();
            //pdfViewerControl.ZoomPercentage=0.1f;
        }

        private void WebView_OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            if (e.Result == WebNavigationResult.Success)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {

            var stream = pdfViewerControl.SaveDocument();
            var filename = _viewModel.SelectedMonth + _viewModel.SelectedYear + "PaySlip.pdf";
            var fileOperations = DependencyService.Get<IFileOperations>();
            var result = fileOperations.SavePDF(filename, stream.GetBytes());
            if (result)
            {
                await UserDialogs.Instance.AlertAsync("Pay slip saved in Documents");
            }
            else
            {
              var perResult=  await UserDialogs.Instance.ConfirmAsync("Do not have required permissions to sae payslip",okText:"Allow Permissions",cancelText:"cancel");
                if (perResult)
                {
                    var result1 = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                    if (result1 == PermissionStatus.Denied)
                    {
                        await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                    }
                }
            }
            //   var file=await filename.CreatePDf(stream);

            //  IFolder folder;
            //var result = await Helper.PdfFolder.IsFolderExistAsync();
            //if (!result)
            //{
            //    folder= await Helper.PdfFolder.CreateFolder();
            //}
            //else
            //{
            //    Helper.PdfFolder.ge
            //}
        }
    }
}