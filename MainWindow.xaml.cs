using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SmurfUltimate
{
    public partial class MainWindow
    {
        private readonly BitmapImage _tab1Sel;
        private readonly BitmapImage _tab1;
        private readonly BitmapImage _tab2Sel;
        private readonly BitmapImage _tab2;
        private readonly BitmapImage _tab3Sel;
        private readonly BitmapImage _tab3;
        private readonly PortBind _portBind;
        public MainWindow()
        {
            InitializeComponent();

            _portBind = new PortBind();
            _portBind.BindPorts();

            _tab1Sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1selected.png"));
            _tab1= new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab1/Tab1.png"));
            _tab2Sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2Selected.png"));
            _tab2 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab2/Tab2.png"));
            _tab3Sel = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3Selected.png"));
            _tab3 = new BitmapImage(new Uri("pack://application:,,,/Resources/Tabs/Tab3/Tab3.png"));
        }

        public void ClosePorts()
        {
            _portBind.ClosePorts();
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
            OverviewTab.Source = _tab1Sel;
            NetworkTab.Source = _tab2;
            ProcessesTab.Source = _tab3;
        }

        private void NetworkUp(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Hidden;
            Network.Visibility = Visibility.Visible;
            Processes.Visibility = Visibility.Hidden;
            OverviewTab.Source = _tab1;
            NetworkTab.Source = _tab2Sel;
            ProcessesTab.Source = _tab3;
        }

        private void ProcessesUp(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Hidden;
            Network.Visibility = Visibility.Hidden;
            Processes.Visibility = Visibility.Visible;
            OverviewTab.Source = _tab1;
            NetworkTab.Source = _tab2;
            ProcessesTab.Source = _tab3Sel;
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
