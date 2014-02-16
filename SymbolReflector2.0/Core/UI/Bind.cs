using System.Windows;
using System.Windows.Input;


namespace SymbolReflector.Core.UI
{
    /// <summary>
    /// Информация о байнде. (Сочетание двух клавиш)
    /// </summary>
    public class Bind: DependencyObject
    {
        /// <summary>
        /// Клавиша 1
        /// </summary>
        public Key Bind1 { get; set; }
        /// <summary>
        /// Клавиша 2
        /// </summary>
        public Key Bind2 { get; set; }
        /// <summary>
        /// Проверка на валидность байнда. Если один из байндов не установлен то байнд неверен.
        /// </summary>
        public bool IsValid { get { return !(Bind1.Equals(Key.None) && Bind2.Equals(Key.None)); } }
    }
}
