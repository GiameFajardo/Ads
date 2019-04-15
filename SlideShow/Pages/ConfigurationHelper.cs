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
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            confCollection["FilePath"].Value =newPath;


            configManager.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);

        }
        public static string GetAdsPath()
        {
            var conf = GetConfigValue("FilePath");
             
            return conf;
        }
        public static string GetConfigValue(string key)
        {
            var conf = ConfigurationManager.AppSettings[key];

            return conf;
        }
    }
}
