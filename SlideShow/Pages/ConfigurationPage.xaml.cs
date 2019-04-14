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
        public ConfigurationPage()
        {
            InitializeComponent();
            mediaContent.Source = new Uri("C:\\Users\\Chu\\Downloads\\animaciones-lectores.mp4");

            mediaContent.LoadedBehavior = MediaState.Manual;
            mediaContent.Play();
            //this.mediaContent.BufferingEnded += MediaContent_BufferingEnded; ;
        }

        private void MediaContent_BufferingEnded(object sender, RoutedEventArgs e)
        {

            this.mediaContent.LoadedBehavior = MediaState.Manual;
            this.mediaContent.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.AnimateOut();

            ((MainWindow)this.Parent).Content = new ImagePage();
        }

        private void mediaContent_BufferingEnded(object sender, RoutedEventArgs e)
        {
            mediaContent.LoadedBehavior = MediaState.Manual;
            mediaContent.Play();
        }

        private void mediaContent_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
