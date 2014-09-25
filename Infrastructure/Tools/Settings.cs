namespace Infrastructure.Tools
{
    using Infrastructure.Configurations;
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// Class to get values in config files
    /// </summary>
    public static class Settings
    {
        private static readonly string[] AppSettingsKeys;

        /// <summary>
        /// Static constructor which init the keys array
        /// </summary>
        static Settings()
        {
            AppSettingsKeys = ConfigurationManager.AppSettings.Keys.Cast<string>().ToArray();
        }

        /// <summary>
        /// Get the key value matching the current environment
        /// </summary>
        private static string GetSetting(string key)
        {
            var keyWithEnvironment = string.Format("{0}_{1}", key, CurrentEnvironment);

            if (AppSettingsKeys.Contains(keyWithEnvironment))
            {
                return ConfigurationManager.AppSettings[keyWithEnvironment];
            }

            if (AppSettingsKeys.Contains(key))
            {
                return ConfigurationManager.AppSettings[key];
            }

            throw new Exception(string.Format(@"Can't find the key ""{0}""", key));
        }

        /// <summary>
        /// Get the current environment
        /// </summary>
        private static string CurrentEnvironment
        {
            get { return ConfigurationManager.AppSettings[SettingKeys.CurrentEnvironment]; }
        }

        #region Public methods

        public static string ConnectionString
        {
            get { return GetSetting(SettingKeys.ConnectionString); }
        }

        public static string SmtpHost
        {
            get { return GetSetting(SettingKeys.SmtpHost); }
        }

        public static string SmtpUserName
        {
            get { return GetSetting(SettingKeys.SmtpUserName); }
        }

        public static string SmtpPassword
        {
            get { return GetSetting(SettingKeys.SmtpPassword); }
        }

        public static string MailingContactFrom
        {
            get { return GetSetting(SettingKeys.MailingContactFrom); }
        }

        public static string MailingContactTo
        {
            get { return GetSetting(SettingKeys.MailingContactTo); }
        }

        #endregion
    }
}