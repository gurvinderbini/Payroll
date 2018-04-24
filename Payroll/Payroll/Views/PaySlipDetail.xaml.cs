using System;
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
using Syncfusion.SfPdfViewer.XForms;
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
            //pdfViewerControl.Toolbar=new Toolbar(){Enabled = false};
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {

          
        }
    }
}