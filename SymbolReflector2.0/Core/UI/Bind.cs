using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Settings = SymbolReflector.Properties.Settings;
using System.Windows.Input;


namespace SymbolReflector.Core.UI
{
    public class Bind: DependencyObject
    {
        public Key Bind1 { get; set; }
        public Key Bind2 { get; set; }
    }
}
