using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Timers;

namespace SmurfUltimate
{
    public partial class MainWindow : Window
    {
        BitmapImage tab1sel;
        BitmapImage tab1;
        BitmapImage tab2sel;
        BitmapImage tab2;
        BitmapImage tab3sel;
        BitmapImage tab3;

        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        PacketBlock packetBlock;

        Timer timer;
        public MainWindow()
        {
            InitializeComponent();

            packetBlock = new PacketBlock();
            packetBlock.bindPorts();

            tab1sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1Selected.png"));
            tab1 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1.png"));
            tab2sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2Selected.png"));
            tab2 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2.png"));
            tab3sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3Selected.png"));
            tab3 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3.png"));
        }

        public void closePorts()
        {
            packetBlock.closePorts();
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
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
