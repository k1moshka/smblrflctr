using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using SymbolReflector.Core.Commands;
using System.Drawing;

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
            AddFilterCommand = new AddSystemFilterCommand();
            RemoveFilterCommand = new RemoveSystemFilterCommand();
            var scr = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            ScreenHeight = scr.Height;
            ScreenWidth = scr.Width;
        }
        #region commands


        public int ScreenHeight
        {
            get { return (int)GetValue(ScreenHeightProperty); }
            set { SetValue(ScreenHeightProperty, value); }
        }

        public static readonly DependencyProperty ScreenHeightProperty =
            DependencyProperty.Register("ScreenHeight", typeof(int), typeof(Context), new UIPropertyMetadata(480));



        public int ScreenWidth
        {
            get { return (int)GetValue(ScreenWidthProperty); }
            set { SetValue(ScreenWidthProperty, value); }
        }

        public static readonly DependencyProperty ScreenWidthProperty =
            DependencyProperty.Register("ScreenWidth", typeof(int), typeof(Context), new UIPropertyMetadata(640));




        public ICommand AddFilterCommand
        {
            get { return (ICommand)GetValue(AddFilterCommandProperty); }
            set { SetValue(AddFilterCommandProperty, value); }
        }
        
        public ICommand RemoveFilterCommand
        {
            get { return (ICommand)GetValue(RemoveFilterCommandProperty); }
            set { SetValue(RemoveFilterCommandProperty, value); }
        }

        public static readonly DependencyProperty AddFilterCommandProperty =
            DependencyProperty.Register("AddFilterCommand", typeof(ICommand), typeof(Context), new UIPropertyMetadata(null));
        
        public static readonly DependencyProperty RemoveFilterCommandProperty =
            DependencyProperty.Register("RemoveFilterCommand", typeof(ICommand), typeof(Context), new UIPropertyMetadata(null));

        #endregion
    }
}
