using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Payroll.Model;
using Plugin.Settings;

namespace Payroll
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private const string DeviceTokenKey = "DeviceTokenKey";
        private static string IsLoggedInKey = "IsLoggedInKey";
        private static string DeviceSecurityPinKey = "DeviceSecurityPinKey";

        private const string PhoneNumberKey = "PhoneNumberKey";
        private const string EntryIDKey = "EntryIDKey";
        private const string NameKey = "NameKey";
        private const string EmailKey = "EmailKey";
        private const string AccountNumberKey = "AccountNumberKey";
        private const string DeviceIDKey = "DeviceIDKey";
        private const string IsVarifiedKey = "IsVarifiedKey";



        private static readonly string SettingsDefault = string.Empty;
        private static readonly string DeviceTokenKeyDefault = string.Empty;
        private const bool IsLoggedInKeyDefault = false;
        private static readonly string DeviceSecurityPinKeyDefault = string.Empty;

        private static readonly string PhoneNumberKeyDefault = string.Empty;
        private static readonly int EntryIDKeyDefault = 0;
        private static readonly string NameKeyDefault = string.Empty;
        private static readonly string EmailKeyDefault = string.Empty;
        private static readonly string AccountNumberKeyDefault = string.Empty;
        private static readonly string DeviceIDKeyDefault = string.Empty;
        private static readonly bool IsVarifiedKeyDefault = false;

        #endregion


        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsKey, value);
        }

        public static string DeviceToken
        {
            get => AppSettings.GetValueOrDefault(DeviceTokenKey, DeviceTokenKeyDefault);
            set => AppSettings.AddOrUpdateValue(DeviceTokenKey, value);
        }
       

        public static bool IsLoggedIn
        {
            get => AppSettings.GetValueOrDefault(IsLoggedInKey, IsLoggedInKeyDefault);
            set => AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
        }

        public static string DeviceSecurityPin
        {
            get => AppSettings.GetValueOrDefault(DeviceSecurityPinKey, DeviceSecurityPinKeyDefault);
            set => AppSettings.AddOrUpdateValue(DeviceSecurityPinKey, value);
        }

        public static string PhoneNumber
        {
            get => AppSettings.GetValueOrDefault(PhoneNumberKey, PhoneNumberKeyDefault);
            set => AppSettings.AddOrUpdateValue(PhoneNumberKey, value);
        }

        public static int EntryID
        {
            get => AppSettings.GetValueOrDefault(EntryIDKey, EntryIDKeyDefault);
            set => AppSettings.AddOrUpdateValue(EntryIDKey, value);
        }
        public static string Name
        {
            get => AppSettings.GetValueOrDefault(NameKey, NameKeyDefault);
            set => AppSettings.AddOrUpdateValue(NameKey, value);
        }
        public static string Email
        {
            get => AppSettings.GetValueOrDefault(EmailKey, EmailKeyDefault);
            set => AppSettings.AddOrUpdateValue(EmailKey, value);
        }
        public static string AccountNumber
        {
            get => AppSettings.GetValueOrDefault(AccountNumberKey, AccountNumberKeyDefault);
            set => AppSettings.AddOrUpdateValue(AccountNumberKey, value);
        }
        public static string DeviceID
        {
            get => AppSettings.GetValueOrDefault(DeviceIDKey, DeviceIDKeyDefault);
            set => AppSettings.AddOrUpdateValue(DeviceIDKey, value);
        }
        public static bool IsVarified
        {
            get => AppSettings.GetValueOrDefault(IsVarifiedKey, IsVarifiedKeyDefault);
            set => AppSettings.AddOrUpdateValue(IsVarifiedKey, value);
        }





    }
}
