using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace LaGranApp.ViewModel.Main
{
    public class viewmodelSimple : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;


        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
