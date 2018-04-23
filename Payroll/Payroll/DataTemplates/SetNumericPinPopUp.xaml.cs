using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using FormsPinView.PCL;
using GalaSoft.MvvmLight;
using Payroll.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetNumericPinPopUp : PopupPage
	{
	 
	    private Home Home;
     private bool _pinIsSet = false;

	    public bool PinIsSet
	    {
	        get => _pinIsSet;
	        set
	        {
	            _pinIsSet = value;
	            MyPinView.Title = _pinIsSet ? "Reset Security Pin" : "Set Security Pin";
	        }
	    }
	



        public SetNumericPinPopUp(Home home)
		{
			InitializeComponent ();
		    Home = home;
		    var viewModel = new SetPinAuthViewModel(this);
		    viewModel.PinViewModel.Success += (object sender, EventArgs e) =>
		    {
		        Home.ViewModel.LayoutVisibility = true;
		        PopupNavigation.PopAsync();
		    };
		    base.BindingContext = viewModel;
        }

	    public class SetPinAuthViewModel : ViewModelBase
	    {
	       
	        private string firstPin  ;
	        private string secondPin ;

            private readonly char[] _correctPin;
	        private readonly PinViewModel _pinViewModel;

	        public PinViewModel PinViewModel => _pinViewModel;

	        public SetPinAuthViewModel(SetNumericPinPopUp setNumericPinPopUp)
	        {

                _pinViewModel = new PinViewModel
	            {
	                TargetPinLength = 4,
	             ValidatorFunc =  (arg) =>
                    {

                        if (arg.Count == 4)
                        {
                            if (setNumericPinPopUp.PinIsSet)
                            {
                                secondPin = string.Join("",arg.ToArray());
                                if (firstPin==secondPin)
                                {
                                    Settings.DeviceSecurityPin = secondPin.ToString();
                                    return true;
                                }
                                else
                                {
                                    firstPin=null;
                                    secondPin=null;
                                    setNumericPinPopUp.PinIsSet = false;
                                }
                              
                            }
                            else
                            {
                                firstPin= string.Join("", arg.ToArray());
                                setNumericPinPopUp.PinIsSet = true;
                                return false;
                            }
                          
                        }

                        return false;
                    },

	            };
	            _pinViewModel.Success += (object sender, EventArgs e) =>
	            {
	                Debug.WriteLine("Success. Assume page will be closed automatically.");
	            };
	        }
	    }

	  
        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    if (PinEntry.Text != Pin2Entry.Text)
        //    {
        //        UserDialogs.Instance.Alert("Both pins dont match");
        //           return;
        //       }
        //    Settings.DeviceSecurityPin = PinEntry.Text;
        //    Home.ViewModel.LayoutVisibility = true;
        //    PopupNavigation.PopAsync();
        //}

        //private void PinEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string _text = PinEntry.Text;   
        //    if (_text.Length > 4)      
        //    {
        //        _text = _text.Remove(_text.Length - 1);  
        //        PinEntry.Text = _text;        
        //    }
        //   }

        //private void Pin2Entry_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string _text = Pin2Entry.Text;      
        //    if (_text.Length > 4)      
        //    {
        //        _text = _text.Remove(_text.Length - 1);  
        //        Pin2Entry.Text = _text;      
        //    }
        //   }
    }
}