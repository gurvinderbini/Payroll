﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

using Payroll.Services;

namespace Payroll.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        #region Variables
        public static INavigationService NavigationService;
        #endregion

        #region CTOR
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region Properties
        private bool _enableLayout=true;

        public bool Enablelayout
        {
            get => _enableLayout;
            set
            {
                _enableLayout = value;
                RaisePropertyChanged();
            }
        }

        private bool _layoutVisibility;

        public bool LayoutVisibility
        {
            get => _layoutVisibility;
            set
            {
                _layoutVisibility = value;
                RaisePropertyChanged();
            }
        }
        private bool _loadingVisibilty;

        public bool LoadingVisibilty
        {
            get => _loadingVisibilty;
            set
            {
                _loadingVisibilty = value;
                Enablelayout = !_loadingVisibilty;
                LayoutOpacity= _loadingVisibilty?.5d:1d;
                RaisePropertyChanged();
            }
        }

        private double _layoutOpacity=1d;

        public double LayoutOpacity
        {
            get => _layoutOpacity;
            set
            {
                _layoutOpacity = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Services
        public static ContactsService ContactsService => new ContactsService();
        public static ValidationService ValidationService => new ValidationService();
        public static PaySlipService PaySlipService=>new PaySlipService();
        #endregion

        #region Commands
        public GalaSoft.MvvmLight.Command.RelayCommand BackCommand => new GalaSoft.MvvmLight.Command.RelayCommand(Back);
        #endregion

        #region Methods
        private void Back()
        {
            NavigationService.GoBack();
        }
        #endregion
    }
}
