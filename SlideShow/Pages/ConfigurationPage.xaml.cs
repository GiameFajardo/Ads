using Avalon.Windows.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlideShow.Pages
{
    /// <summary>
    /// Interaction logic for ConfigurationPage.xaml
    /// </summary>
    public partial class ConfigurationPage : BasePage
    {
        public string SelectedPath { get; set; }
        public ConfigurationPage()
        {
            InitializeComponent();
            txtPath.Text = ConfigurationHelper.GetAdsPath();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationHelper.ChangeFilePath(SelectedPath);
            ((MainWindow)(this.Parent)).ReLoadAds();
            this.AnimateOut();
            //((MainWindow)(this.Parent)).StartStopTimer();

        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)(this.Parent)).ReLoadAds();
        }

        private void btnGetNewPath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            d.RootType = RootType.SpecialFolder;
            d.RootSpecialFolder = Environment.SpecialFolder.Desktop;
            d.RootPath =  ConfigurationHelper.GetAdsPath(); 
            
            if (d.ShowDialog().Value)
            {
                SelectedPath = d.SelectedPath;
                txtPath.Text = SelectedPath;
            }
            else
            {

            }
            
           
        }
    }
}
