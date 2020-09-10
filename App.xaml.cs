using System.ComponentModel;
using System.Windows;
namespace SmurfUltimate
{
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        private MainWindow mainWindow;

        private string versionName;
        private string versionCode;
        private string author;
        private string discord;
        protected override void OnStartup(StartupEventArgs e)
        {
            versionName = (string)Application.Current.FindResource("versionName");
            versionCode = (string)Application.Current.FindResource("versionCode");
            author = (string)Application.Current.FindResource("author");
            discord = (string)Application.Current.FindResource("discord");

            base.OnStartup(e);
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();

            mainWindow = splashScreen.mainWindow;

            mainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = new System.Drawing.Icon("Resources/Icons/icon.ico");
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.Text = versionName;
            _notifyIcon.ContextMenuStrip.Items.Add("Open " + versionName).Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("About").Click += (s, e) => ShowAbout();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ShowAbout()
        {
            string messageBoxText = "Version: " + versionCode + "\n" + "Author: " + author + "\n" + "Discord: " + discord;
            string caption = versionName;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void ExitApplication()
        {
            _isExit = true;
            mainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (mainWindow.IsVisible)
            {
                if (mainWindow.WindowState == WindowState.Minimized)
                {
                    mainWindow.WindowState = WindowState.Normal;
                }
                mainWindow.Activate();
            }
            else
            {
                mainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                mainWindow.Hide();
            }
        }
    }
}
