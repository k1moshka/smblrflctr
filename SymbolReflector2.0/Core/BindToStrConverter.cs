using System;
using System.Windows.Data;
using SymbolReflector.Core.UI;

namespace SymbolReflector.Core
{
    /// <summary>
    /// WPF конвертер Bind в строкове представление
    /// </summary>
    public class BindToStrConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var bind = value as Bind;
            if (bind != null && bind.IsValid)
            {
                var result = (bind.Bind1).ToString() + "+";
                result += (bind.Bind2).ToString();

                return result;
            }
            return "None+None";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Данная операция не поддерживается");
        }
    }
}
