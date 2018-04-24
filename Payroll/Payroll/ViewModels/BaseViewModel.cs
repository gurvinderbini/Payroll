﻿using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using Payroll.Interfaces;
using Payroll.Services;
using Xamarin.Forms;

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

        #endregion

        #region Services
        public static ContactsService ContactsService => new ContactsService();

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
