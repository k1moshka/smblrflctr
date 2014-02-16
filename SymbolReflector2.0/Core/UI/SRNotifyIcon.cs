using System.Windows.Forms;
using System.Windows;
using Mproject.System.Messaging;

namespace SymbolReflector.Core.UI
{
    /// <summary>
    /// Класс управляющий состоянием иконки в трэе
    /// </summary>
    public class SRNotifyIcon
    {
        private bool isHided;
        private NotifyIcon _notify;
        private Window _mainWindow;

        /// <summary>
        /// Инциализирует новый экземпляр класса.
        /// </summary>
        /// <param name="mainWindow">Окно отображенем которого управляет данный экземпляр</param>
        public SRNotifyIcon(Window mainWindow)
        {
            _notify = new NotifyIcon();
            _mainWindow = mainWindow;
            init_contextMenu();
            _notify.Icon = SymbolReflector.Properties.Resources.NotifyIcon;
            _notify.Text = "Symbol reflector @ 2014";
            _notify.DoubleClick += (o, e) =>
                {
                    showHideWindow();
                };
            _notify.Visible = true;
        }

        private void init_contextMenu()
        {
            ContextMenu menu = new ContextMenu();
            MenuItem menu_show = new MenuItem();
            menu_show.Text = "Показать";
            menu_show.Click += (sender, args) =>
            {
                showHideWindow();
            };
            //------------------------------------------------------------------------------------------------------
            MenuItem item_offhook = new MenuItem();
            item_offhook.Text = "Отключить глобальный байнд";
            item_offhook.Click += (sender, args) =>
            {
                var filter = KeyboardFilterHandler.Filter;
                var connector = FilterConnector.Instance;
                if (KeyboardFilterHandler.FilterApplied)
                {
                    connector.RemoveFilter(filter);
                    item_offhook.Text = "Включить глобальный байнд";
                }
                else
                {
                    connector.ApplyFilter(filter);
                    item_offhook.Text = "Отключить глобальный байнд";
                }
            };
            //------------------------------------------------------------------------------------------------------
            MenuItem menu_exit = new MenuItem();
            menu_exit.Text = "Выход";
            menu_exit.Click += (sender, args) =>
            {
                _mainWindow.Close();
            };

            menu.MenuItems.AddRange(new MenuItem[] {
                                    menu_show, 
                                    item_offhook,
                                    new System.Windows.Forms.MenuItem("-"), 
                                    menu_exit});

            _notify.ContextMenu = menu;
        }

        #region toggle-функция показа/сокрытия окна
        private void showHideWindow()
        {
            if (isHided)
                showWindow();
            else
                hideWindow();
        }

        private void hideWindow()
        {
            _mainWindow.Hide();
            isHided = true;
        }

        private void showWindow()
        {
            _mainWindow.Show();
            _mainWindow.Activate();
            isHided = false;
        }
        #endregion
    }
}
