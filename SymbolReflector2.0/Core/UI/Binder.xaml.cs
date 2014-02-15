using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Settings = SymbolReflector.Properties.Settings;


namespace SymbolReflector.Core.UI
{
    /// <summary>
    /// Interaction logic for Binder.xaml
    /// </summary>
    public partial class Binder : UserControl
    {
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
            if (this._keys.Contains(key))
            {
                this._keys.Remove(key);

                if (this._keys.Count.Equals(0))
                {
                    this.key1down = this.key2down = false;
                    Settings.Default.BindKey2 = KeyInterop.VirtualKeyFromKey(e.Key);
                    updateBind();
                }
                else
                    Settings.Default.BindKey1 = KeyInterop.VirtualKeyFromKey(e.Key);
            }
            e.Handled = true;
        }

        private void updateBind()
        {
            this.Bind = new Bind()
            {
                Bind1 = KeyInterop.KeyFromVirtualKey(Settings.Default.BindKey1),
                Bind2 = KeyInterop.KeyFromVirtualKey(Settings.Default.BindKey2)
            };
        }
    }
}
