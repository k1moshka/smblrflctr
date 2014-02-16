using System;
using SymbolReflector.Core;
using System.Windows;
using SymbolReflector.Core.UI;
using Microsoft.Win32;

namespace SymbolReflector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private StringChanger changer; // управляет процессом обработки строк
        private SRNotifyIcon notifyIcon;

        internal static RegistryKey startUpKey;
        internal static string pathToApp;

        public App()
        {
            startUpKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            pathToApp = System.Reflection.Assembly.GetExecutingAssembly().Location;
            
            changer = new StringChanger();
            KeyboardFilterHandler.BindDown += new EventHandler<EventArgs>(KeyboardFilterHandler_BindDown);
            this.Activated += new EventHandler(App_Activated);
            this.Exit += (o, e) =>
                {
                    SymbolReflector.Properties.Settings.Default.Save();
                };
        }

        private void App_Activated(object sender, EventArgs e)
        {
            notifyIcon = new SRNotifyIcon(this.MainWindow);
            this.Activated -= App_Activated;
        }

        [STAThread]
        private void KeyboardFilterHandler_BindDown(object sender, EventArgs e)
        {
            changer.Cut();
            string wrong_str;
            try
            {
                wrong_str = Clipboard.GetText(TextDataFormat.UnicodeText).ToLower();
                changer.Process(wrong_str);
            }
            catch (Exception)
            {
                MessageBox.Show("Can not open clipboard.");
            }
        }
    }
}
