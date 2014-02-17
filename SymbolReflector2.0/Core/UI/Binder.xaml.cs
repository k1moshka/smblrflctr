using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Settings = SymbolReflector.Properties.Settings;


namespace SymbolReflector.Core.UI
{
    /// <summary>
    /// UI оболочка класса Bind
    /// </summary>
    public partial class Binder : UserControl
    {
        /// <summary>
        /// Текущий байнд для контрола
        /// </summary>
        public Bind Bind
        {
            get { return (Bind)GetValue(BindProperty); }
            set { SetValue(BindProperty, value); }
        }

        public static readonly DependencyProperty BindProperty =
            DependencyProperty.Register("Bind", typeof(Bind), typeof(Binder), new UIPropertyMetadata());

        private List<int> _keys;

        private bool key1down;
        private bool key2down;

        public Binder()
        {
            InitializeComponent();

            this._keys = new List<int>();
            this.key1down = this.key2down = false;
            updateBind();
        }

        #region детект установки нового байнда
        private void Text_bind_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat && !key1down)
            {
                this._keys.Add((int)e.Key);
                key1down = true;
            }
            else if (!e.IsRepeat && !key2down)
            {
                this._keys.Add((int)e.Key);
                key2down = true;
            }
            e.Handled = true;
        }

        private void Text_bind_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var key = (int)e.Key;
            if (this._keys.Contains(key) && this.key1down && this.key2down)
            {
                this._keys.Remove(key);

                if (this._keys.Count.Equals(0))
                {
                    resetKeydownHandlers();
                    Settings.Default.BindKey2 = KeyInterop.VirtualKeyFromKey(e.Key);
                    updateBind();
                }
                else
                    Settings.Default.BindKey1 = KeyInterop.VirtualKeyFromKey(e.Key);
            }
            else
                resetKeydownHandlers();
            e.Handled = true;
        }

        private void resetKeydownHandlers()
        {
            // устанавливает как ненажатыми клавиши
            this.key1down = this.key2down = false;
            _keys.Clear();
        }
        #endregion

        private void updateBind()
        {
            // загрузка байнда из настроек приложения
            this.Bind = new Bind()
            {
                Bind1 = KeyInterop.KeyFromVirtualKey(Settings.Default.BindKey1),
                Bind2 = KeyInterop.KeyFromVirtualKey(Settings.Default.BindKey2)
            };
        }

        internal void ResetBind()
        {
            // установка дефолтных настроек байнда для приложения и апдейт текстбокса
            Settings.Default.BindKey1 = 0;
            Settings.Default.BindKey2 = 0;
            updateBind();
        }
    }
}
