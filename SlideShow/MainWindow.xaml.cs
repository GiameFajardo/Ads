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

        public List<AdPage> AdsPages { get; set; }
        public ConfigurationPage ConfigurationPage { get; set; }
        public int Index { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            defaultSeconds = ConfigurationHelper.GetAdsDuration();
            LoadAds();

            ConfigurationPage = new ConfigurationPage();

            ÌnitializeTimer();
            StartStopTimer();
            
        }

        private void ÌnitializeTimer()
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
            var files = Directory.GetFiles(dirPath);

            foreach (string path in files)
            {

                ip = new AdPage(Color.FromRgb(12, 12, 12),
                    path);
                ip.KeyDown += Window_KeyDown;
                AdsPages.Add(ip);
            }

            this.Content = AdsPages[Index];
        }

        public void ReLoadAds()
        {
            //StartStopTimer();
            mediaPositionTimer.Start();
            _is_playing = true;

            Index = 0;

            LoadAds();
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
                if (currentDuration >= defaultSeconds)
                {
                    NextAd();
                }
            }
            if (!_is_playing)
            {
                
            }
        }

        public void ShowConf()
        {
            this.Content = ConfigurationPage;
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
                default:
                    break;
            }
        }
    }
}
