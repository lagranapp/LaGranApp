using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LaGranAppUI.ViewModel.Helpers
{
    public abstract class viewmodelNotify : INotifyPropertyChanged
    {
        #region Notify"
        #region INotifyPropertyChanged Members  
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion

    }
}
