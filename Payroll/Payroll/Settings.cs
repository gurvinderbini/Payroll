using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;

namespace Payroll
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private const string DeviceTokenKey = "DeviceTokenKey";
        private const string UsernameKey = "UsernameKey";
        private const string PasswordKey = "PasswordKey";
        private const string LoginTokenKey = "LoginTokenKey";
        private const string MainWebServiceUrlKey = "MainWebServiceUrlKey";
        private const string ContactListKey = "ContactListKey";
        private const string ContactsKey = "ContactsKey";

        private static readonly string SettingsDefault = string.Empty;
        private static readonly string DeviceTokenKeyDefault = string.Empty;
        private static readonly string UsernameKeyDefault = string.Empty;
        private static readonly string PasswordKeyDefault = string.Empty;
        private static readonly string LoginTokenKeyDefault = string.Empty;
        private static readonly string MainWebServiceUrlDefault = "http://ezblast.pink/";
        private static readonly string ContactListDefault = "Contact/GetLists";
        private static readonly string ContactsDefault = "Contact/GetContacts";

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string DeviceToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(DeviceTokenKey, DeviceTokenKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DeviceTokenKey, value);
            }
        }

        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault(UsernameKey, UsernameKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UsernameKey, value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(PasswordKey, PasswordKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(PasswordKey, value);
            }
        }

        public static string MainWebServiceUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(MainWebServiceUrlKey, MainWebServiceUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(MainWebServiceUrlKey, value);
            }
        }

        public static string LoginToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoginTokenKey, LoginTokenKeyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoginTokenKey, value);
            }
        }
        public static string ContactList
        {
            get
            {
                return AppSettings.GetValueOrDefault(ContactListKey, ContactListDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ContactListKey, value);
            }
        }
        public static string Contacts
        {
            get
            {
                return AppSettings.GetValueOrDefault(ContactsKey, ContactsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(ContactsKey, value);
            }
        }



    }
}
