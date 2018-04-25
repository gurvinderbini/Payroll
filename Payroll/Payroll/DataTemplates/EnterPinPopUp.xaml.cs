using FormsPinView.PCL;
using GalaSoft.MvvmLight;
using Payroll.ViewModels;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Linq;
using System.Diagnostics;

using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnterPinPopUp : PopupPage
	{
	    public EnterPinPopUp (HomeViewModel home)
		{
		    InitializeComponent();
		    var viewModel = new PinAuthViewModel();
	        viewModel.PinViewModel.Success += (object sender, EventArgs e) =>
	        {
	            home.LayoutVisibility = true;
	                 PopupNavigation.PopAsync();
            };
	        base.BindingContext = viewModel;
	    }

	    protected override bool OnBackButtonPressed() => false;
	}

    public class PinAuthViewModel : ViewModelBase
    {
        private readonly char[] _correctPin;
        private readonly PinViewModel _pinViewModel;

        public PinViewModel PinViewModel => _pinViewModel;

        public PinAuthViewModel()
        {

            _correctPin = Settings.DeviceSecurityPin.ToCharArray();// new[] { '1', '2', '3', '4' };
            _pinViewModel = new PinViewModel
            {
                TargetPinLength = 4,
                ValidatorFunc = (arg) => Enumerable.SequenceEqual(arg, _correctPin)
            };
            _pinViewModel.Success += (object sender, EventArgs e) =>
            {
                Debug.WriteLine("Success. Assume page will be closed automatically.");
            };
        }
    }
}