using LaGranAppBLL.Modulos.Usuarios;
using LaGranAppCAS.Helpers;
using LaGranAppDAL.Model.Usuario;
using LaGranAppUI.View.Modulos.Usuarios;
using LaGranAppUI.View.Window;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Windows;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;

namespace LaGranAppUI.ViewModel.Modulos.Usuarios
{
    public class viewmodelUsuariosList : Helpers.viewmodelBase, IviewmodelUsuariosList
    {
        #region "Propiedades"
        
        private int _PageIndex;
        private IBLLUsuarios _BLLUsuarios;
        private IPlugin _Plugin;
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private List<lgaUsuarios> _Usuarios;
        private readonly IviewmodelUsuarios _vmMantUsuarios;
        private readonly ILogger<viewmodelUsuariosList> _logger;

        public List<lgaUsuarios> Usuarios
        {
            get { return _Usuarios; }
            set { _Usuarios = value; }
        }

        #endregion
        public viewmodelUsuariosList(IBLLUsuarios BLLUsuarios, IPlugin plugin, IviewmodelUsuarios vmMantUsuarios, ILogger<viewmodelUsuariosList> logger)
        {
            try
            {
                _BLLUsuarios = BLLUsuarios;
                _vmMantUsuarios = vmMantUsuarios;
                _Plugin = plugin;
                _logger = logger;
                ms_FillGrid();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }            
        }

        public override void CanExecuteChanged(object sender, object e)
        {
            try
            {

                switch (sender)
                {
                    case "Nuevo":
                        ms_ShowWindow(0);
                        break;
                    case "Primero":
                        _PageIndex = 1;
                        ms_FillGrid();
                        break;
                    case "Previo":
                        if (_PageIndex > 1) { _PageIndex -= 1; ms_FillGrid(); }
                        break;
                    case "Siguiente":
                        _PageIndex += 1;
                       ms_FillGrid();
                        break;
                    default:
                        ms_ShowWindow(int.Parse(sender.ToString()));
                        ms_FillGrid();
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        private void ms_FillGrid()
        {
            try
            {
                _Usuarios = _BLLUsuarios.List(_Plugin.AppId, _PageIndex).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
        private void ms_ShowWindow(int UsuarioId)
        {
            try
            {
                viewUsuarios _view = new viewUsuarios();

                viewWindow window = new viewWindow()
                {
                    Title = "Mantenimiento de usuarios",
                    Content = _view,
                    WindowStyle = WindowStyle.SingleBorderWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    SizeToContent = SizeToContent.Width,
                    Height = 600,
                    Width = 800,
                    Owner = Window.GetWindow(Application.Current.MainWindow),
                    MinWidth = 800,
                    MinHeight=600,
                    ShowInTaskbar=false
                };
                _vmMantUsuarios.Id = UsuarioId;
                window.DataContext = _vmMantUsuarios;
                window.ShowDialog();
                ms_FillGrid();
                OnPropertyChanged("Usuarios");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
