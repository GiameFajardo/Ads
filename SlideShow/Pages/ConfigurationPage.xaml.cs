using Avalon.Windows.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string SelectedDuration { get; set; }
        public string SelectedMessageDuration { get; set; }
        public string SelectedPriceDuration { get; set; }
        public ConfigurationPage()
        {
            PageLoadAnimation = Animation.PageAnimation.FadeIn;
            InitializeComponent();
            txtPath.Text = SelectedPath = ConfigurationHelper.GetAdsPath();
            txtDuration.Text = SelectedDuration = ConfigurationHelper.GetAdsDuration().ToString();
            txtMessage.Text = SelectedMessageDuration = ConfigurationHelper.GetMessageDuration().ToString();
            txtPrice.Text = SelectedPriceDuration = ConfigurationHelper.GetPriceDuration().ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigurationHelper.ChangeFilePath(SelectedPath);
            ConfigurationHelper.ChangeAdsDuration(SelectedDuration);
            ConfigurationHelper.ChangeMessageDuration(SelectedMessageDuration);
            ConfigurationHelper.ChangePriceDuration(SelectedPriceDuration);
            ((MainWindow)(this.Parent)).ReLoadAds();
            //this.AnimateOut();
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TxtDuration_KeyDown(object sender, KeyEventArgs e)
        {
            SelectedDuration = txtDuration.Text;
        }

        private void TxtDuration_KeyUp(object sender, KeyEventArgs e)
        {
            SelectedDuration = txtDuration.Text;
        }

        private void BtnPrice_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)(this.Parent)).ShowPrice("APP123");
        }

        private void TxtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            SelectedPriceDuration = txtPrice.Text;
        }

        private void TxtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            SelectedMessageDuration = txtMessage.Text;
        }
    }
}
