using SlideShow.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Configuration;
using System.Text.RegularExpressions;
using SlideShow.Context;

namespace SlideShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double defaultSeconds = 20;
        double currentDuration = 0;
        double totalDuration = 0;
        private double mediaDuration;
        private DispatcherTimer mediaPositionTimer;
        private bool _is_playing;
        private bool hasWrongPath = false;
        private bool showingPrice { get; set; }

        public List<AdPage> AdsPages { get; set; }
        public ConfigurationPage ConfigurationPage { get; set; }
        public MessagePage MessagePage { get; set; }
        public PricePage PricePage { get; set; }
        public int Index { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();

            txtSearch.Focus();
             
            ConfigurationPage = new ConfigurationPage();
            ConfigurationPage.KeyDown += Window_KeyDown;
            MessagePage = new MessagePage();
            MessagePage.KeyDown += Window_KeyDown;
            PricePage = new PricePage();
            PricePage.KeyDown += Window_KeyDown;
            defaultSeconds = ConfigurationHelper.GetAdsDuration();
            LoadAds();

            StartStopTimer();
            
        }

        private void InitializeTimer()
        {
            mediaPositionTimer = new DispatcherTimer();

            // Set up the timer     
            mediaPositionTimer.Interval = TimeSpan.FromSeconds(1);
            mediaPositionTimer.Tick += new EventHandler(positionTimerTick);
        }

        public void LoadAds()
        {
            AdsPages = new List<AdPage>();
            AdPage ip;
            string dirPath = ConfigurationHelper.GetAdsPath();
            defaultSeconds = ConfigurationHelper.GetAdsDuration();
            string[] files = GetFiles(dirPath);

            foreach (string path in files)
            {
                ip = new AdPage(Color.FromArgb(0,0,0,0),
                    path);
                ip.KeyDown += Window_KeyDown;
                AdsPages.Add(ip);
            }
            if (AdsPages.Count>0)
            {
                this.Content = AdsPages[Index];
            }
        }

        private string[] GetFiles(string dirPath)
        {
            string[] files = new string[]{ };
            try
            {
                files = Directory.GetFiles(dirPath);
                hasWrongPath = false;
            }
            catch (Exception)
            {
                hasWrongPath = true;
                ShowMessage("Wrong path",true);
                mediaPositionTimer.Stop();
            }
            return files;
        }
        public void RemovePage(AdPage page)
        {
            AdsPages.Remove(page);
        }
        public void ReLoadAds()
        {
            //StartStopTimer();
            mediaPositionTimer.Start();
            _is_playing = true;

            Index = 0;

            LoadAds();
        }

        public void StopTimer()
        {

            mediaPositionTimer.Stop();
            _is_playing = false;
            
        }
        public void StartStopTimer()
        {

            if (!_is_playing)
            {
                mediaPositionTimer.Start();
                _is_playing = true;
            }
            else
            {
                mediaPositionTimer.Stop();
                _is_playing = false;
            }
        }

        public void NextAd()
        {
            showingPrice = false;
            if (Index >= AdsPages.Count - 1)
            {
                Index = 0;
            }
            else
            {
                Index++;
            }
            this.Content = AdsPages[Index];
            currentDuration = 0;
        }

        private void positionTimerTick(object sender, EventArgs e)
        {
            if (!hasWrongPath)
            {

                var naturalDuration = AdsPages[Index].mediaContent.NaturalDuration;

                currentDuration += mediaPositionTimer.Interval.TotalSeconds;
                if (naturalDuration.HasTimeSpan)
                {

                    totalDuration = AdsPages[Index].mediaContent.Position.TotalSeconds;

                    mediaDuration = AdsPages[Index].mediaContent.NaturalDuration.TimeSpan.TotalSeconds;
                    if (totalDuration >= mediaDuration)
                    {
                        NextAd();
                    }
                }
                else
                {
                    if (currentDuration >= (defaultSeconds+ AdsPages[Index].SlideSeconds))
                    {
                        NextAd();
                    }
                }
                if (!_is_playing)
                {
                
                }
            }
            else
            {
                mediaPositionTimer.Stop();
                ShowMessage("Wrong path", true);
            }
        }

        public void ShowConf()
        {
            this.Content = ConfigurationPage;
        }
        public void ShowPrice(string filter)
        {
            DataAccess da = new DataAccess();
            try
            {
                Item i = da.GetItem(filter);
                if (i != null)
                {

                    PricePage.Item = i;
                    this.Content = PricePage;
                }
                else
                {
                    ShowMessage("Lectura no valida.");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lectura no valida.");
            }
           
        }
        public void ShowMessage(string message, bool stop = false)
        {
            MessagePage.Message = message;
            MessagePage.Stop = stop;
            this.Content = MessagePage;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            


            switch (e.Key)
            {
                case Key.F6:
                    {
                        StartStopTimer();
                        ShowConf();
                    }
                    break;
                case Key.F5:
                    {
                        ReLoadAds();
                    }
                    break;
                case Key.F7:
                    {
                        FullScreen();
                    }
                    break;
                case Key.Enter:
                    {
                        StopTimer();
                        var a = txtSearch.Text;
                        ShowPrice(a);
                        CleanField();
                        showingPrice = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void FullScreen()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
            }
        }

        private void TxtSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_TextInput(object sender, TextCompositionEventArgs e)
            {
            if (e.Text == "\r")
            {
                CleanField();
            }
            else
            {

                txtSearch.Text += e.Text;
            }
            //if (showingPrice)
            //{

            //    txtSearch.Text = string.Empty;
            //}
            //else
            //{

            //}


        }
        public void CleanField()
        {

            txtSearch.Text = string.Empty;
        }
    }
}
