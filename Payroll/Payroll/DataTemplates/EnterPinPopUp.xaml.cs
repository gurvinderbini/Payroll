using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FormsPinView.PCL;
using GalaSoft.MvvmLight;
using Payroll.Interfaces;
using Payroll.ViewModels;
using Payroll.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnterPinPopUp : PopupPage
	{
	    private Home Home;

        public EnterPinPopUp (Home home)
		{
			InitializeComponent();
		    Home = home;
	        var viewModel = new PinAuthViewModel();
	        viewModel.PinViewModel.Success += (object sender, EventArgs e) =>
	        {
	            Home.ViewModel.LayoutVisibility = true;
	                 PopupNavigation.PopAsync();
            };
	        base.BindingContext = viewModel;
	    }

	    protected override bool OnBackButtonPressed() => false;



     //   private void PinEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    //{
	    //    string _text = PinEntry.Text;      //Get Current Text
	    //    if (_text.Length > 4)       //If it is more than your character restriction
	    //    {
	    //        _text = _text.Remove(_text.Length - 1);  // Remove Last character
	    //        PinEntry.Text = _text;        //Set the Old value
	    //    }
     //   }

	    //private async void Button_OnClicked(object sender, EventArgs e)
	    //{
	    //    if (PinEntry.Text == Settings.DeviceSecurityPin)
	    //    {
	    //        Home.ViewModel.LayoutVisibility = true;
	    //        PopupNavigation.PopAsync();

     //       }
     //       else
	    //    {
	    //      var result=await  UserDialogs.Instance.ConfirmAsync("Invalid Pin", null, "Close App", "Retry");
	    //        if (result)
	    //        {
     //               DependencyService.Get<ICloseApplication>().CloseApp();;
	    //        }
	    //    }
     //   }
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