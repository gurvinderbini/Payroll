using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Payroll.Views;
using Plugin.DeviceInfo;
using Plugin.Messaging;
using Xamarin.Forms;

namespace Payroll
{
	public partial class MainPage : ContentPage
	{
	    private string _receiverMobileNumber = "9023309984";
        public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
		}

	    protected override bool OnBackButtonPressed()
	    {
	        return true;
	    }

	    private async void Button_OnClicked(object sender, EventArgs e)
	    {
	      

	        if (CrossMessaging.Current.SmsMessenger.CanSendSmsInBackground)
	        {
	            UserDialogs.Instance.ShowLoading("Authenticating");
	            await Task.Delay(500);
	            Settings.DeviceToken= CrossDevice.Device.DeviceId;
	            var deviceEncryptData = Helpers.Helper.GetSha1HashData(Settings.DeviceToken);
	            CrossMessaging.Current.SmsMessenger.SendSmsInBackground(_receiverMobileNumber, deviceEncryptData);
	            UserDialogs.Instance.HideLoading();
	            Settings.DeviceToken = CrossDevice.Device.DeviceId;
	          await  Navigation.PushAsync(new Home());
                return;

	        }
	        if (CrossMessaging.Current.SmsMessenger.CanSendSms)
	        {
	            var deviceEncryptData = Helpers.Helper.GetSha1HashData(Settings.DeviceToken);
	            CrossMessaging.Current.SmsMessenger.SendSms(_receiverMobileNumber, deviceEncryptData);
	            Settings.DeviceToken = CrossDevice.Device.DeviceId;
            }
	        else
	        {
	          await  UserDialogs.Instance.AlertAsync("Your mobile dont have messaging permissions");
	        }

        }

	    private async void Validate()
	    {
	        

	    }
    }
}
