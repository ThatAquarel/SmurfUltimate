using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SmurfUltimate
{
    public partial class MainWindow
    {
        private BitmapImage tab1sel;
        private BitmapImage tab1;
        private BitmapImage tab2sel;
        private BitmapImage tab2;
        private BitmapImage tab3sel;
        private BitmapImage tab3;
        private PortBind portBind;
        public MainWindow()
        {
            InitializeComponent();

            portBind = new PortBind();
            portBind.BindPorts();

            tab1sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1Selected.png"));
            tab1 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1.png"));
            tab2sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2Selected.png"));
            tab2 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2.png"));
            tab3sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3Selected.png"));
            tab3 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3.png"));
        }

        public void ClosePorts()
        {
            portBind.ClosePorts();
        }

        private void MinimizeClick(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void CloseClick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OverviewUp(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Visible;
            Network.Visibility = Visibility.Hidden;
            Processes.Visibility = Visibility.Hidden;
            OverviewTab.Source = tab1sel;
            NetworkTab.Source = tab2;
            ProcessesTab.Source = tab3;
        }

        private void NetworkUp(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Hidden;
            Network.Visibility = Visibility.Visible;
            Processes.Visibility = Visibility.Hidden;
            OverviewTab.Source = tab1;
            NetworkTab.Source = tab2sel;
            ProcessesTab.Source = tab3;
        }

        private void ProcessesUp(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Hidden;
            Network.Visibility = Visibility.Hidden;
            Processes.Visibility = Visibility.Visible;
            OverviewTab.Source = tab1;
            NetworkTab.Source = tab2;
            ProcessesTab.Source = tab3sel;
        }

        private void WindowDrag(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
