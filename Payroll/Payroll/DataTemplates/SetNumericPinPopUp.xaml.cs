using System;
using System.Linq;
using System.Diagnostics;

using FormsPinView.PCL;
using GalaSoft.MvvmLight;
using Payroll.ViewModels;

using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms.Xaml;

namespace Payroll.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetNumericPinPopUp : PopupPage
    {
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


        public SetNumericPinPopUp(HomeViewModel home)
        {
            InitializeComponent();
            var viewModel = new SetPinAuthViewModel(this);
            viewModel.PinViewModel.Success += (object sender, EventArgs e) =>
            {
                home.LayoutVisibility = true;
                PopupNavigation.PopAsync();
            };
            base.BindingContext = viewModel;
        }

        public class SetPinAuthViewModel : ViewModelBase
        {

            private string _firstPin;
            private string _secondPin;

            //private readonly char[] _correctPin;
            private readonly PinViewModel _pinViewModel;

            public PinViewModel PinViewModel => _pinViewModel;

            public SetPinAuthViewModel(SetNumericPinPopUp setNumericPinPopUp)
            {
                _pinViewModel = new PinViewModel
                {
                    TargetPinLength = 4,
                    ValidatorFunc = (arg) =>
                      {

                          if (arg.Count == 4)
                          {
                              if (setNumericPinPopUp.PinIsSet)
                              {
                                  _secondPin = string.Join("", arg.ToArray());
                                  if (_firstPin == _secondPin)
                                  {
                                      Settings.DeviceSecurityPin = _secondPin.ToString();
                                      return true;
                                  }
                                  _firstPin = null;
                                  _secondPin = null;
                                  setNumericPinPopUp.PinIsSet = false;
                              }
                              else
                              {
                                  _firstPin = string.Join("", arg.ToArray());
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
    }
}