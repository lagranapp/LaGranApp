using LaGranApp.Model.Loader;
using LaGranAppPlugin;
using LaGranAppUI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Windows;

namespace LaGranApp.ViewModel.Loader
{
    public class viewmodelLoader : viewmodelBase, IviewmodelLoader
    {
        private List<IPlugin> _Items;

        public List<IPlugin> Items
        {
            get { return _Items; }
            set 
            {
                _Items = value; 
                OnPropertyChanged("Items"); 
            }
        }

        private IPlugin _sItem;

        public IPlugin sItem
        {
            get { return _sItem; }
            set 
            { 
                _sItem = value;
                Application.Current.MainWindow.OwnedWindows[Application.Current.MainWindow.OwnedWindows.Count - 1].Close();
            }
        }

        public viewmodelLoader()
        {
            try
            {
                //_Items = new List<Plugin>();
            }
            catch { }
        }
    }
}
