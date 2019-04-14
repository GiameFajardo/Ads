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

        public List<AdPage> Pages { get; set; }
        public ConfigurationPage ConfigurationPage { get; set; }
        public int Index { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            Pages = new List<AdPage>();
            AdPage ip;
            var files = Directory.GetFiles("C:\\Users\\Chu\\Downloads\\Ads");

            foreach (string path in files)
            {

                ip = new AdPage(Color.FromRgb(12,12,12), 
                    path);
                Pages.Add(ip);
            }


            this.Content = Pages[Index];

            ConfigurationPage = new ConfigurationPage();


            if (mediaPositionTimer == null)
            {
                mediaPositionTimer = new DispatcherTimer();
                // Set up the timer     
                mediaPositionTimer.Interval = TimeSpan.FromSeconds(1);
                mediaPositionTimer.Tick += new EventHandler(positionTimerTick);
                mediaPositionTimer.Start();
            }
            else
            {
                mediaPositionTimer.Stop();
            }
        }

        private void Media_BufferingStarted(object sender, RoutedEventArgs e)
        {
          
        }

        private void Media_BufferingEnded(object sender, RoutedEventArgs e)
        {
            
        }

        public void Next()
        {
            
            if (Index >= Pages.Count - 1)
            {
                Index = 0;
            }
            else
            {
                Index++;
            }
            this.Content = Pages[Index];
            currentDuration = 0;
        }

        private void positionTimerTick(object sender, EventArgs e)
        {
                var naturalDuration = Pages[Index].mediaContent.NaturalDuration;

            currentDuration += mediaPositionTimer.Interval.TotalSeconds;
            if (naturalDuration.HasTimeSpan)
            {

                totalDuration = Pages[Index].mediaContent.Position.TotalSeconds;

                mediaDuration = Pages[Index].mediaContent.NaturalDuration.TimeSpan.TotalSeconds;
                if (totalDuration >= mediaDuration)
                {
                    Next();
                }
            }
            else
            {
                if (currentDuration >= defaultSeconds)
                {
                    Next();
                }
            }
        }

        public void Conf()
        {
            this.Content = ConfigurationPage;
        }
    }
}
