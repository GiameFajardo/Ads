using SlideShow.Pages;
using System;
using System.Collections.Generic;
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

namespace SlideShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ImagePage> Pages { get; set; }
        public int Index { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            Pages = new List<ImagePage>();
            ImagePage ip;

            ip = new ImagePage(Color.FromRgb(12,12,12));
            Pages.Add(ip);

            ip = new ImagePage(Color.FromRgb(34, 53, 6));
            Pages.Add(ip);

            ip = new ImagePage(Color.FromRgb(45, 64, 98));
            Pages.Add(ip);


            this.Content = Pages[Index];

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
        }
    }
}
