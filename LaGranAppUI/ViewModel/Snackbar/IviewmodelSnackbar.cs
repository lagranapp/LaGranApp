using MaterialDesignThemes.Wpf;

namespace LaGranAppUI.ViewModel.Snackbar
{
    public interface IviewmodelSnackbar
    {
        SnackbarMessageQueue BoundMessageQueue { get; set; }
        string Message { set; }
    }
}