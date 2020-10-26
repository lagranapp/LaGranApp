using LaGranAppBLL.Modulos.Menu;
using LaGranAppCAS.Helpers;
using LaGranAppDAL.Model.Menu;
using LaGranAppUI.ViewModel.Helpers;
using LaGranAppUI.Model.Menu;
using LaGranAppUI.ViewModel.Snackbar;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace LaGranAppUI.ViewModel.Modulos.MenuRoles
{
    public class viewmodelMenuRoles : viewmodelBase, IviewmodelMenuRoles
    {
        private readonly IPlugin _plugin;
        private readonly IBLLMenuRoles _bllMenuRoles;
        private readonly ILogger<viewmodelMenuRoles> _logger;
        private readonly IviewmodelSnackbar _snackbar;

        #region "Propiedades"        
        public ObservableCollection<modelMenuItem> MenuItems
        {
            get
            {
                return _plugin.AppMenu as ObservableCollection<modelMenuItem>;
            }
        }

        private modelMenuItem _sMenuItems;
        public modelMenuItem sMenuItems
        {
            get
            {
                return _sMenuItems;
            }
            set
            {
                _sMenuItems = value;
            }
        }

        private string _Nodo;
        public string Nodo
        {
            get { return _Nodo; }
            set { _Nodo = value; }
        }

        public string[] Roles
        {
            get
            {
                return _plugin.AppRoles;
            }
        }

        private string _sRole;
        public string sRole
        {
            get { return _sRole; }
            set { _sRole = value; }
        }

        private List<lgaMenuRoles> _lstMenuRoles;

        public List<lgaMenuRoles> lstMenuRoles
        {
            get { return _lstMenuRoles; }
            set { _lstMenuRoles = value; OnPropertyChanged("lstMenuRoles"); }
        }


        #endregion

        public viewmodelMenuRoles(IPlugin plugin, IBLLMenuRoles bllMenuRoles, ILogger<viewmodelMenuRoles> logger, IviewmodelSnackbar snackbar)
        {
            try
            {
                _plugin = plugin;
                _bllMenuRoles = bllMenuRoles;
                _logger = logger;
                _snackbar = snackbar;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

        }


        public override void CanExecuteChanged(object sender, object e)
        {
            try
            {
                if (sender.GetType() != typeof(int))
                {
                    switch (sender)
                    {
                        case "AnadirRole":
                            if (sRole != null)
                            {
                                var oData = new lgaMenuRoles() { AppId = _plugin.AppId.ToString(), RoleId = sRole, MenuId = sMenuItems.ID };
                                if (_bllMenuRoles.Create(oData))
                                {
                                    _snackbar.Message = "Registro creado exitosamente !";
                                }
                            }
                            break;
                        default:
                            var x = sender as modelMenuItem;
                            if (x.ID > 0)
                            {
                                sMenuItems = x;
                                Nodo = sMenuItems.Header;
                            }
                            else
                            {
                                Nodo = string.Empty;
                                sMenuItems = new modelMenuItem();
                                sMenuItems.ID = 0;
                            }
                            break;
                    }

                }
                else
                {
                    int valor = int.Parse(sender.ToString());
                    if (_bllMenuRoles.Delete(_bllMenuRoles.Read(_plugin.AppId, valor))) _snackbar.Message = "Registro eliminado exitosamente.";
                }
                lstMenuRoles = _bllMenuRoles.List(_plugin.AppId, sMenuItems.ID).ToList();
                OnPropertyChanged(string.Empty);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
