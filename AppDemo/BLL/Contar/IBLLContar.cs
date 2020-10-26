using AppDemo.Model.Contar;

namespace AppDemo.BLL.Contar
{
    public interface IBLLContar
    {        
        AppContar Read(int Id);
        bool Update(AppContar Entidad);
    }
}