namespace LaGranAppUI.ViewModel.Modulos.Usuarios
{
    public interface IviewmodelUsuariosList
    {
        int PageIndex { get; set; }

        void CanExecuteChanged(object sender, object e);
    }
}