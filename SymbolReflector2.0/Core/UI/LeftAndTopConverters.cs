using System;
using System.Windows.Data;

namespace SymbolReflector.Core.UI
{
    /// <summary>
    /// WPF-конвертер положения левого края окна, так что бы окно находилось максимально справа
    /// </summary>
    public class LeftConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var screen_width = (int)value;
            var wnd_width = App.Current.MainWindow.Width;

            return screen_width - wnd_width;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// WPF-конвертер положения верхнего края окна, так что бы окно находилось максимально внизу
    /// </summary>
    public class TopConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var screen_height = (int)value;
            var wnd_height = App.Current.MainWindow.Height;

            return screen_height - wnd_height;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
