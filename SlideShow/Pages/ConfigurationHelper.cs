using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideShow.Pages
{
    public static class ConfigurationHelper
    {
        public static void ChangeFilePath(string newPath)
        {
            ChangeConfValue("FilePath", newPath);
        }
        public static void ChangeAdsDuration(string duration)
        {
            ChangeConfValue("AdsDuration", duration);
        }
        public static void ChangeMessageDuration(string duration)
        {
            ChangeConfValue("MessageDuration", duration);
        }
        public static void ChangePriceDuration(string duration)
        {
            ChangeConfValue("PriceDuration", duration);
        }
        public static string GetAdsPath()
        {
            var conf = GetConfigValue("FilePath");
             
            return conf;
        }
        public static double GetAdsDuration()
        {
            var conf = GetConfigValue("AdsDuration");
            double duration = double.Parse(conf);
            
            return duration;
        }
        public static double GetMessageDuration()
        {
            var conf = GetConfigValue("MessageDuration");
            double duration = double.Parse(conf);

            return duration;
        }
        public static double GetPriceDuration()
        {
            var conf = GetConfigValue("PriceDuration");
            double duration = double.Parse(conf);

            return duration;
        }
        private static string GetConfigValue(string key)
        {
            var conf = ConfigurationManager.AppSettings[key];

            return conf;
        }
        private static void ChangeConfValue(string key,string value)
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            confCollection[key].Value = value;


            configManager.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);

        }
    }
}
