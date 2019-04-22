using SlideShow.Context;
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
    /// Interaction logic for PricePage.xaml
    /// </summary>
    public partial class PricePage : BasePage, INotifyPropertyChanged
    {
        double duration = 0d;
        double PriceDuration = ConfigurationHelper.GetPriceDuration();
        private DispatcherTimer mediaPositionTimer;
        private Item _Item;
        public Item Item { get { return _Item; }
            set
            {
                Price = double.Parse(value.PRECCRED);
                OldPrice = double.Parse(value.PRECCONT);
                ItemDescription = value.DESCARTI;
                _Item = value;
                OnPropertyChanged();
            }
        }

        private string _ItemDescription = "";
        public string ItemDescription
        {
            get
            {
                return _ItemDescription;
            }
            set
            {
                _ItemDescription = value;
                OnPropertyChanged();
            }
        }

        private double _Price = 0d;
        public double Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                OnPropertyChanged();
                duration = 0d;
                mediaPositionTimer.Start();
                if (this.Parent != null)
                {

                    //((MainWindow)this.Parent).CleanField();
                }
            }
        }

        private double _OldPrice = 0d;
        public double OldPrice
        {
            get { return _OldPrice; }
            set { _OldPrice = value; OnPropertyChanged(); }
        }

        public PricePage()
        {
            InitializeTimer();
            PageLoadAnimation = Animation.PageAnimation.FadeIn;
            InitializeComponent();
            DataContext = this;
            //Item = new Item();
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
            if (duration >= PriceDuration)
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
