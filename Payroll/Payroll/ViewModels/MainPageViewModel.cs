using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Payroll.Helpers;
using Payroll.Model;
using Payroll.NavigationService;
using Plugin.DeviceInfo;

namespace Payroll.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public Contact Contact { get; set; }

       


        public void Navigate()
        {
           NavigationService.NavigateTo(ViewModelLocator.Home);
        }
    }
}
