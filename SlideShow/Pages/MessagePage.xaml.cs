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
    /// Interaction logic for MessagePage.xaml
    /// </summary>
    public partial class MessagePage : BasePage
    {
        public string Message { get; set; } = "TEST";
        public MessagePage()
        {
            InitializeComponent();

            txtMessage.Text = Message;
        }
        public MessagePage(string message)
        {
            InitializeComponent();
            txtMessage.Text = Message = message;
        }
    }
}
