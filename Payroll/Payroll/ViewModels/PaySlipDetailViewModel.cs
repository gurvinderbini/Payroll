using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Acr.UserDialogs;

using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Command;

using Payroll.Extensions;
using Payroll.DataTemplates;

using Rg.Plugins.Popup.Services;

namespace Payroll.ViewModels
{
    public class PaySlipDetailViewModel : BaseViewModel
    {
        #region CTOR
        public PaySlipDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            for (var i = 2000; i < 2019; i++)
            {
                YearsList.Add(i.ToString());
            }

        }

        #endregion

        #region Properties
        private string _selectedYear = String.Empty;

        public string SelectedYear
        {
            get => _selectedYear;
            set
            {
                _selectedYear = value;
                RaisePropertyChanged();
            }
        }

        public int SelectedMonthNumber { get; set; }

        private string _selectedMonth = String.Empty;

        public string SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
                RaisePropertyChanged();

                if (!String.IsNullOrEmpty(SelectedMonth))
                {
                    var index = MonthsList.IndexOf(SelectedMonth);
                    SelectedMonthNumber = index + 1;
                }
            }
        }
        private Stream _pdfDocumentStream;
        public Stream PdfDocumentStream
        {
            get => _pdfDocumentStream;
            set
            {
                _pdfDocumentStream = value;
                SaveVisibilty = _pdfDocumentStream != null;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> MonthsList => new ObservableCollection<string>()
        {
            "January","Febuary","March","April","May","June","July","August","September","October","November","December"
        };


        private ObservableCollection<string> _yearsList = new ObservableCollection<string>();

        public ObservableCollection<string> YearsList
        {
            get => _yearsList;
            set
            {
                _yearsList = value;
                RaisePropertyChanged();
            }
        }

        private bool _saveVisibilty = false;
        public bool SaveVisibilty
        {
            get => _saveVisibilty;
            set
            {
                _saveVisibilty = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand DatePickerPopupCommand => new RelayCommand(DatePickerPopup);
        public RelayCommand SaveCommand => new RelayCommand(Save);
        public RelayCommand SearchCommand => new RelayCommand(Search);

        private void DatePickerPopup()
        {
            PopupNavigation.PushAsync(new PaySlipDatePopUp(this));
        }
        private void Save()
        {

        }

        private async void Search()
        {
            //UserDialogs.Instance.ShowLoading("Generating Payslip ! Please wait");
            //var result = await PaySlipService.GetPaySlip(SelectedMonthNumber, Convert.ToInt32(SelectedYear), Helpers.Helper.AutoRetreivedDeviceId);
            //if (result.Success == "true")
            //{
            //    var url = result.Payslip;
            //    PdfDocumentStream = await Task.Run(() => url.ConvertToStream());
            //}
            //else
            //{
            //    await UserDialogs.Instance.AlertAsync(result.Message);
            //}

            //UserDialogs.Instance.HideLoading();
        }

        #endregion

        #region Events
        public void Initilize()
        {
            try
            {
                //PdfDocumentStream = Stream.Null;
                //SelectedMonth = SelectedYear = String.Empty;
            }
            catch (Exception e)
            { }

        }
        #endregion
    }
}
