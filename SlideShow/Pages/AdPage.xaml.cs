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
using System.Windows.Threading;

namespace SlideShow.Pages
{
    /// <summary>
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class AdPage : BasePage
    {
        
        public AdPage()
        {
            InitializeComponent();
        }
        public AdPage(Color background)
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(background);
        }
        public AdPage(Color background, string media)
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(background);
            this.mediaContent.Source = new Uri(media);
            this.mediaContent.BufferingEnded += MediaContent_BufferingEnded;
            //this.mediaContent.LoadedBehavior = MediaState.Manual;
            //this.mediaContent.Play();
        }

        private void MediaContent_BufferingEnded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.AnimateOut();


            ((MainWindow)this.Parent).NextAd();
        }

        private void mediaContent_BufferingEnded(object sender, RoutedEventArgs e)
        {
            this.mediaContent.LoadedBehavior = MediaState.Manual;
            this.mediaContent.Play();
        }

        private void mediaContent_BufferingStarted(object sender, RoutedEventArgs e)
        {

        }

        private void mediaContent_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void mediaContent_TouchUp(object sender, TouchEventArgs e)
        {

        }

        private void mediaContent_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            ((MainWindow)this.Parent).ShowConf();
        }

        private void mediaContent_MediaEnded(object sender, RoutedEventArgs e)
        {

            //((MainWindow)this.Parent).Next();
        }

        private void mediaContent_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
