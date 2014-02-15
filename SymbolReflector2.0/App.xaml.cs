using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using SymbolReflector.Core;
using System.Windows;
using System.Threading;
using SymbolReflector.Core.UI;

namespace SymbolReflector
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private StringChanger changer;
        private SRNotifyIcon notifyIcon;

        public App()
        {
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
        void KeyboardFilterHandler_BindDown(object sender, EventArgs e)
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
