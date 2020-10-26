using LaGranAppDAL.Model.Menu;
using LaGranAppUI.Model.Menu;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LaGranAppUI.ViewModel.Modulos.MenuRoles
{
    public interface IviewmodelMenuRoles
    {
        List<lgaMenuRoles> lstMenuRoles { get; set; }
        ObservableCollection<modelMenuItem> MenuItems { get; }
        string Nodo { get; set; }
        string[] Roles { get; }
        modelMenuItem sMenuItems { get; set; }
        string sRole { get; set; }

        void CanExecuteChanged(object sender, object e);
    }
}