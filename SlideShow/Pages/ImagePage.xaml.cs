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
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class ImagePage : BasePage
    {
        public ImagePage()
        {
            InitializeComponent();
        }
        public ImagePage(Color background)
        {
            InitializeComponent();
            Background = new SolidColorBrush(background);
        }   

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.AnimateOut();


            ((MainWindow)this.Parent).Next();
        }
    }
}
