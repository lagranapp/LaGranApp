using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace LaGranApp.Model.Tabs
{
    public class modelTabs
    {
        private bool _isSelected;

        public string Name { get; set; }

        public UserControl SimpleContent { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
#if NET40
                OnPropertyChanged("IsSelected");
#endif
#if NET45
                OnPropertyChanged();
#endif                
            }
        }
    }
}
