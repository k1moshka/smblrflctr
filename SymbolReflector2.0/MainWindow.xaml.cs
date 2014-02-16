using System.Windows;

namespace SymbolReflector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region установка сценария запуска прилдения при старте ОС
        private void check_startup_Checked(object sender, RoutedEventArgs e)
        {
            App.startUpKey.SetValue("Symbol Reflector", App.pathToApp);
            Properties.Settings.Default.IsStartWithOS = true;
        }

        private void check_startup_Unchecked(object sender, RoutedEventArgs e)
        {
            App.startUpKey.DeleteValue("Symbol Reflector");
            Properties.Settings.Default.IsStartWithOS = false;
        }
        #endregion
    }
}
