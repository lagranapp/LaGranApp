namespace AppDemo.ViewModel.Procesos.Contar
{
    public interface IviewmodelContar
    {
        int Contador { get; set; }

        void CanExecuteChanged(object sender, object e);
    }
}