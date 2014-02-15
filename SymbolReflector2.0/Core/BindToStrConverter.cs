using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using SymbolReflector.Core.UI;
using System.Windows.Input;

namespace SymbolReflector.Core
{
    public class BindToStrConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var bind = value as Bind;
            if (bind != null)
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
