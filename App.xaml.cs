using System.ComponentModel;
using System.Windows;
namespace SmurfUltimate
{
    public partial class App
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        private MainWindow _mainWindow;
        private SplashScreen _splashScreen;

        private string _versionName;
        private string _versionCode;
        private string _author;
        private string _discord;
        protected override void OnStartup(StartupEventArgs e)
        {
            _versionName = (string)Current.FindResource("VersionName");
            _versionCode = (string)Current.FindResource("VersionCode");
            _author = (string)Current.FindResource("Author");
            _discord = (string)Current.FindResource("Discord");

            base.OnStartup(e);
            _splashScreen = new SplashScreen();
            _splashScreen.Show();

            _mainWindow = _splashScreen.mainWindow;

            _mainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = new System.Drawing.Icon("Resources/Icons/icon.ico");
            _notifyIcon.Visible = true;

            CreateContextMenu();

            //Engine.findProcessInSystray();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            Process.KillLsk();

            _splashScreen.mainWindow.ClosePorts();

            Process.StartLsk();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.Text = _versionName;
            _notifyIcon.ContextMenuStrip.Items.Add("Open " + _versionName).Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("About").Click += (s, e) => ShowAbout();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ShowAbout()
        {
            string messageBoxText = "Version: " + _versionCode + "\n" + "Author: " + _author + "\n" + "Discord: " + _discord;
            string caption = _versionName;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void ExitApplication()
        {
            _isExit = true;
            _mainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (_mainWindow.IsVisible)
            {
                if (_mainWindow.WindowState == WindowState.Minimized)
                {
                    _mainWindow.WindowState = WindowState.Normal;
                }
                _mainWindow.Activate();
            }
            else
            {
                _mainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                _mainWindow.Hide();
            }
        }
    }
}
