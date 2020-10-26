using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Windows;

namespace LaGranAppUI.Model.Menu
{
    public class modelMenuItem 
    {
        private Visibility _Visible = Visibility.Collapsed;
        public string Header { get; set; }
        public MaterialDesignThemes.Wpf.PackIcon Icon { get; set; }
        public int ID { get; set; }

        public Visibility Visible { get { return _Visible; } set { _Visible = value; } }
        public ObservableCollection<modelMenuItem> MenuItems { get; set; }
        
    }
}
