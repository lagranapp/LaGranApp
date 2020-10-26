using System.ComponentModel;
using System.Windows.Input;

namespace LaGranAppUI.ViewModel.Helpers
{
    public interface IviewmodelBase
    {
        ICommand Command { get; }
        bool IsAuthenticated { get; }
        string Username { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void CanExecuteChanged(object sender, object e);
        void Login(object parameter);
        void OnPropertyChanged(string propertyName);
    }
}