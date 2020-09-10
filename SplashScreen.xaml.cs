using System;
using System.Windows;
using System.Windows.Threading;

namespace SmurfUltimate
{
    public partial class SplashScreen : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow mainWindow;
        public SplashScreen()
        {
            InitializeComponent();

            mainWindow = new MainWindow();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
        }

        private void dispatcherTimerTick(object sender, EventArgs e)
        {
            mainWindow.Show();

            dispatcherTimer.Stop();
            this.Close();
        }
    }
}
