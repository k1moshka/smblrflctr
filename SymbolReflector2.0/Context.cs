using System.Windows.Input;
using System.Windows;
using SymbolReflector.Core.Commands;

namespace SymbolReflector
{
    // viewmodel mainwindow
    public class Context: DependencyObject
    {
        #region singleton
        private static Context _cur;

        public static Context Current
        {
            get { return _cur ?? (_cur = new Context()); }
        }
        #endregion

        private Context() 
        {
            // init dep props
            AddFilterCommand = new AddSystemFilterCommand();
            RemoveFilterCommand = new RemoveSystemFilterCommand();
            var scr = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            ScreenHeight = scr.Height;
            ScreenWidth = scr.Width;
        }
        
        /// <summary>
        /// Показывает запускаеться ли приложение вместе с ОС. Извлекаеться из сохранненых настроек.
        /// </summary>
        public bool IsStartWithOS { get { return Properties.Settings.Default.IsStartWithOS; } set { } } // immitation setvalue for support wpf-binding
        /// <summary>
        /// Текущая высота экрана в пикселях
        /// </summary>
        public int ScreenHeight
        {
            get { return (int)GetValue(ScreenHeightProperty); }
            set { SetValue(ScreenHeightProperty, value); }
        }
        /// <summary>
        /// Текущая ширина экрана в пикселях
        /// </summary>
        public int ScreenWidth
        {
            get { return (int)GetValue(ScreenWidthProperty); }
            set { SetValue(ScreenWidthProperty, value); }
        }

        


        #region commands
        /// <summary>
        /// 
        /// </summary>
        public ICommand AddFilterCommand
        {
            get { return (ICommand)GetValue(AddFilterCommandProperty); }
            set { SetValue(AddFilterCommandProperty, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICommand RemoveFilterCommand
        {
            get { return (ICommand)GetValue(RemoveFilterCommandProperty); }
            set { SetValue(RemoveFilterCommandProperty, value); }
        }
        #endregion

        #region register dep props
        public static readonly DependencyProperty ScreenWidthProperty =
            DependencyProperty.Register("ScreenWidth", typeof(int), typeof(Context), new UIPropertyMetadata(640));

        public static readonly DependencyProperty ScreenHeightProperty =
            DependencyProperty.Register("ScreenHeight", typeof(int), typeof(Context), new UIPropertyMetadata(480));

        public static readonly DependencyProperty AddFilterCommandProperty =
            DependencyProperty.Register("AddFilterCommand", typeof(ICommand), typeof(Context), new UIPropertyMetadata(null));

        public static readonly DependencyProperty RemoveFilterCommandProperty =
            DependencyProperty.Register("RemoveFilterCommand", typeof(ICommand), typeof(Context), new UIPropertyMetadata(null));

        #endregion
    }
}
