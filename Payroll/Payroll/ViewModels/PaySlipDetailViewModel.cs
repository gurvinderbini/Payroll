using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Payroll.ViewModels
{
    public class PaySlipDetailViewModel:BaseViewModel
    {
        #region CTOR
        public PaySlipDetailViewModel(INavigationService navigationService) : base(navigationService)
        {

           
        }

        #endregion

        #region Properties

        private bool _pickerVisibilty;

        public bool PickerVisibilty
        {
            get => _pickerVisibilty;
            set
            {
                _pickerVisibilty = value;
                RaisePropertyChanged();
            }
        }



        public ObservableCollection<string> MonthsList => new ObservableCollection<string>()
        {
            "January","Febuary","March","April","May","June","July","August","September","October","November","December"
        };


        private ObservableCollection<string> _yearsList=new ObservableCollection<string>();

        public ObservableCollection<string> YearsList
        {
            get => _yearsList;
            set
            {
                _yearsList = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        // 
        public RelayCommand SelectPickerCommand => new RelayCommand(SelectPicker);
        public RelayCommand SearchCommand=>new RelayCommand(Search);

        private void SelectPicker()
        {
            PickerVisibilty = true;
        }

        private void Search()
        {

        }
        #endregion

        #region Events

        public void Initilize()
        {
            YearsList.Clear();
            for (int i = 2000; i < 2019; i++)
            {
                YearsList.Add(i.ToString());
            }
        }

        private void Back()
        {
            NavigationService.GoBack();
        }
        #endregion
    }
}
