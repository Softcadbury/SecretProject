namespace Infrastructure.Tools
{
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// Class to get values of initializes in config files
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
        public static string GetSetting(string key)
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

        public static string CurrentEnvironment
        {
            get { return ConfigurationManager.AppSettings["Current_Environment"]; }
        }

        public static string ConnectionString
        {
            get { return GetSetting("Connection_String"); }
        }

        public static string SmtpHost
        {
            get { return GetSetting("Smtp_Host"); }
        }

        public static string SmtpUserName
        {
            get { return GetSetting("Smtp_User_Name"); }
        }

        public static string SmtpPassword
        {
            get { return GetSetting("Smtp_Password"); }
        }

        public static string MailingContactFrom
        {
            get { return GetSetting("Mailing_Contact_From"); }
        }

        public static string MailingContactTo
        {
            get { return GetSetting("Mailing_Contact_To"); }
        }
    }
}