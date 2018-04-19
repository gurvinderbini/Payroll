using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Payroll.DataTemplates;
using Payroll.Helpers;
using Payroll.Model;
using Payroll.Views;
using Plugin.DeviceInfo;
using Plugin.Messaging;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace Payroll
{
    public partial class MainPage : ContentPage
    {
        //Layout private SfPopupLayout SfPopupLayout;

        public MainPage()
        {
            InitializeComponent();
            clickToShowPopup.Clicked += ClickToShowPopup_Clicked;
            Layout.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            Layout.PopupView.AcceptButtonText = "Yes, Its me !";
            Layout.PopupView.DeclineButtonText = "No, Thats not me !";
            Layout.PopupView.HeaderTitle = "Your Details";
            Layout.PopupView.ContentTemplate=new CredentialsPopUp();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            Layout.Show();
        }
     
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Layout.IsVisible = false;
            UserDialogs.Instance.ShowLoading("Authenticating");
            await Validate(CrossDevice.Device.DeviceId, Settings.Contact);
            UserDialogs.Instance.HideLoading();
            Layout.IsVisible = true;
        }


       
        private async Task<Contact> Validate(string deviceToken, string contact)
        {
            try
            {

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri(Helper.BaseUrl);
                var endpoint = String.Format(Helper.GetContacts, deviceToken, contact);
                var result = await httpClient.GetAsync(endpoint);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var str = await result.Content.ReadAsStringAsync();
                    var contactModel = JsonConvert.DeserializeObject<Contact>(str);
                    return contactModel;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
           

        }


    }
}
