using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaGranAppUI.ViewModel.Snackbar
{
    public class viewmodelSnackbar : IviewmodelSnackbar
    {
        private static SnackbarMessageQueue _BoundMessageQueue = new SnackbarMessageQueue();

        public SnackbarMessageQueue BoundMessageQueue
        {
            get
            {                
                return _BoundMessageQueue;
            }
            set
            {
                _BoundMessageQueue = value;
            }
        }

        public string Message
        {
            set
            {
                BoundMessageQueue.Enqueue(value);
            }
        }      
    }
}