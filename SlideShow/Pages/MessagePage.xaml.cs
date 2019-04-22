using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MessagePage.xaml
    /// </summary>
    public partial class MessagePage : BasePage, INotifyPropertyChanged
    {
        private string _message;// = "TEST";
        double duration = 0d;
        double MessageDuration = ConfigurationHelper.GetMessageDuration();
        private DispatcherTimer mediaPositionTimer;
        public string Message {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");

                duration = 0d;
                if (mediaPositionTimer != null)
                {

                    mediaPositionTimer.Start();
                }
                if (this.Parent != null)
                {

                    ((MainWindow)this.Parent).CleanField();
                }
            }
        }

        public bool Stop { get; set; }

        public MessagePage()
        {
            PageLoadAnimation = Animation.PageAnimation.FadeIn;
            InitializeTimer();
            InitializeComponent();
            DataContext = this;
            //txtMessage.Text = Message;
        }
        public MessagePage(string message)
        {
            PageLoadAnimation = Animation.PageAnimation.FadeIn;
            InitializeTimer();
            InitializeComponent();
            DataContext = this;
            //txtMessage.Text = Message = message;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        private void InitializeTimer()
        {
            mediaPositionTimer = new DispatcherTimer();

            // Set up the timer     
            mediaPositionTimer.Interval = TimeSpan.FromSeconds(1);
            mediaPositionTimer.Tick += new EventHandler(positionTimerTick);
        }

        private void positionTimerTick(object sender, EventArgs e)
        {
            duration += 1;
            if (duration >= MessageDuration && !Stop)
            {

                duration = 0d;
                mediaPositionTimer.Stop();
                if (this.Parent != null)
                {

                    ((MainWindow)(this.Parent)).ReLoadAds();
                }
            }
        }
    }
}
