using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using LaGranApp.Helpers;
using LaGranAppCAS.Security;
using LaGranAppPlugin;
using LaGranAppUI.Model.Menu;
using LaGranApp.View.Login;
using LaGranAppDAL.Model.Usuario;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.CRUD;
using LaGranAppBLL.Modulos.Configuracion;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using LaGranAppDAL.Modulos.Menu;
using LaGranAppDAL.Modulos.Configuracion;
using LaGranAppDAL.Modulos.Usuarios;
using LaGranAppBLL.Modulos.Menu;
using LaGranAppBLL.Modulos.Usuarios;
using LaGranAppDAL.DatabaseContext;
using LaGranApp.ViewModel.Login;
using LaGranAppUI.ViewModel.Helpers;
using System.IO;
using System;
using LaGranAppUI.ViewModel.Modulos.Usuarios;
using LaGranAppUI.ViewModel.Modulos.MenuRoles;
using LaGranAppUI.ViewModel.Snackbar;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using LaGranAppUI.ViewModel.Mantenimiento.Bitacora;
using LaGranApp.View.Loader;
using LaGranApp.ViewModel.Loader;
using LaGranApp.Model.Tabs;
using MahApps.Metro.Controls;

namespace LaGranApp.ViewModel.Main
{
    public class viewmodelMain : viewmodelBase
    {
        private ICollection<IPlugin> _plugins;
        private IPlugin _oPlugin = null;        
        
        private IHostBuilder _IHostBuilder;
        private IHost _IHost;
        #region "Propiedades"   
        public SnackbarMessageQueue BoundMessageQueue
        {
            get
            {
                try
                {
                    if (_IHost != null) return ActivatorUtilities.CreateInstance<viewmodelSnackbar>(_IHost.Services).BoundMessageQueue;
                    else return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        #region "TABS"
        private ObservableCollection<modelTabs> _Tabs = new ObservableCollection<modelTabs>();
        public ObservableCollection<modelTabs> Tabs
        {
            get { return _Tabs; }
            set
            {
                _Tabs = value;
                OnPropertyChanged("Tabs");
            }
        }
        private modelTabs _sTabs;
        public modelTabs sTabs
        {
            get { return _sTabs; }
            set
            {
                if (_sTabs == value) return;
                _sTabs = value;
                OnPropertyChanged("sTabs");
            }
        }

        #endregion
        #region "APP"
        private string _AppTitle=string.Empty;
        public string AppTitle
        {
            get
            {
                return _AppTitle;
            }
            set
            {
                _AppTitle = value;
                OnPropertyChanged("AppTitle");
            }
        }

        private PackIconKind  _AppIcon = PackIconKind.Apps;
        public PackIconKind  AppIcon
        {
            get 
            {
                return _AppIcon;
                
            }
            set { _AppIcon = value;
                OnPropertyChanged("AppIcon");
            }
        }
        #endregion
        public Dragablz.TabablzControl TabContainer { get; set; }
        #region "MENUS"
        private ObservableCollection<modelMenuItem> _MenuItems;
        public ObservableCollection<modelMenuItem> MenuItems
        {
            get
            {
                return _MenuItems;
            }
            set
            {
                _MenuItems = value;                
                OnPropertyChanged("MenuItems");
            }
        }
        #endregion
        #endregion


        public viewmodelMain()
        {
            try
            {
                
                HostingServices();
                Loader();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #region "HOSTING SERVICES"
        private void HostingServices()
        {
            _IHostBuilder = Host.CreateDefaultBuilder()
            .ConfigureLogging(logging =>
            {                
                // clear default logging providers                    
                logging.ClearProviders();
                    
                // add built-in providers manually, as needed                    
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventLog(c => c.SourceName = "LGA");
                logging.AddEventSourceLogger();
                   
                })
            .ConfigureServices((context, services) =>
            {
                    
                #region "DAL"                   
                services.AddDbContext<ILaGranAppDbContext, LaGranAppDbContext>(options => options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));
                services.AddTransient<IDALConfiguracion, DALConfiguracion>();
                services.AddTransient<IDALMenuRoles, DALMenuRoles>();
                services.AddTransient<IDALUsuarios, DALUsuarios>();
                services.AddTransient<IDALUsuariosRoles, DALUsuariosRoles>();
                    
                #endregion
                    
                #region "BLL"
                services.AddTransient<IBLLConfiguracion, BLLConfiguracion>();
                services.AddTransient<IBLLMenuRoles, BLLMenuRoles>();
                services.AddTransient<IBLLUsuarios, BLLUsuarios>();
                services.AddTransient<IBLLUsuariosRoles, BLLUsuariosRoles>();

                #endregion

                #region "CAS"
                services.AddSingleton<ICASAuthenticationService,CASAuthenticationService>();
                services.AddSingleton<LaGranAppCAS.Helpers.IPlugin, LaGranAppCAS.Helpers.Plugin>();

                #endregion

                #region "PLUGIN"
                services.AddSingleton<IPlugin, Plugin>();

                #endregion

                #region "PRESENTATION"                
                services.AddTransient<IviewmodelBase, viewmodelLogin>();
                services.AddTransient<IviewmodelUsuariosList, viewmodelUsuariosList>();
                services.AddTransient<IviewmodelUsuarios, viewmodelUsuarios>();
                services.AddTransient<IviewmodelMenuRoles, viewmodelMenuRoles>();
                services.AddSingleton<IviewmodelSnackbar, viewmodelSnackbar>();
                services.AddTransient<IviewmodelBitacora, viewmodelBitacora>();
                #endregion


                }); 

        }


        #endregion

        #region "PLUGIN"
        private void Loader()
        {
            try
            {
                _plugins = PluginLoader<IPlugin>.LoadPlugins(Directory.GetCurrentDirectory() + "\\plugins");

                if (_plugins != null)
                {

                    if (_plugins.Count >1)
                    {
                        viewLoader viewLoader = new viewLoader();
                        viewmodelLoader vmLoader = new viewmodelLoader();
                        vmLoader.Items = _plugins.ToList();
                        viewLoader.DataContext = vmLoader;
                        viewLoader.Owner = Application.Current.MainWindow;
                        viewLoader.ShowDialog();
                        _oPlugin = vmLoader.sItem;
                        ms_SelectedApp();
                    }
                    else
                    {
                        _oPlugin = _plugins.FirstOrDefault();
                        ms_SelectedApp();
                    }
                    AppTitle = _oPlugin.AppNombre;
                    AppIcon = _oPlugin.AppIco;
                }
            }
            catch
            {
                throw;
            }
        }
        private void ms_SelectedApp()
        {
            try
            {                
                _oPlugin.AppIHostBuilder = _IHostBuilder;
                _IHost = _IHostBuilder.Build();                
                _oPlugin.AppIHost = _IHost;
                #region "copia de plugin para injectar en las instancias"  
                var _Plugin = ActivatorUtilities.CreateInstance<LaGranAppCAS.Helpers.Plugin>(_IHost.Services);
                _Plugin.AppIco = _oPlugin.AppIco;
                if(_oPlugin.AppId!=null)_Plugin.AppId = _oPlugin.AppId;
                if(_oPlugin.AppLicense !=null)_Plugin.AppLicense = _oPlugin.AppLicense;
                if(_oPlugin.AppLicFileName !=null)_Plugin.AppLicFileName = _oPlugin.AppLicFileName;
                _Plugin.AppNombre = _oPlugin.AppNombre;
                _Plugin.AppReqLicense = _oPlugin.AppReqLicense;
                _Plugin.AppReqMantUsuarios = _oPlugin.AppReqMantUsuarios;
                if (_oPlugin.AppMenu != null) _Plugin.AppMenu = _oPlugin.AppMenu;
                if (_oPlugin.AppRoles != null) _Plugin.AppRoles = _oPlugin.AppRoles;
                #endregion

                if (_oPlugin.AppReqLicense)
                {

                }
                
                if (_oPlugin.AppReqMantUsuarios)
                {
                    var Usuarios = ActivatorUtilities.CreateInstance<BLLUsuarios>(_IHost.Services);
                    var oUsuarioRoles = ActivatorUtilities.CreateInstance<BLLUsuariosRoles >(_IHost.Services);

                    if (Usuarios.List(_oPlugin.AppId).Count > 0)
                    {
                        Login();
                    }
                }
                
                OnPropertyChanged("BoundMessageQueue");

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
        #region "LOGIN"
        private void Login()
        {
            try
            {
                viewLogin viewLogin = new viewLogin();
                viewLogin.DataContext = ActivatorUtilities.CreateInstance<viewmodelLogin>(_IHost.Services);
                viewLogin.Owner = Application.Current.MainWindow;
                viewLogin.ShowDialog();
                var UsuarioAutenticado = ActivatorUtilities.CreateInstance<CASAuthenticationService>(_IHost.Services);
                if (UsuarioAutenticado.AuthenticatedUser != null)
                {
                    if (UsuarioAutenticado.AuthenticatedUser.Roles.Length > 0)
                    {
                        var oMenuRoles = ActivatorUtilities.CreateInstance<BLLMenuRoles>(_IHost.Services);
                        var Resultado = oMenuRoles.List(UsuarioAutenticado.AuthenticatedUser.Id, _oPlugin.AppId);

                        MenuItems = _oPlugin.AppMenu;

                        foreach (var oItem in Resultado)
                        {
                            FindMenuItem(oItem.MenuId, MenuItems);  // MenuItems);
                        }                        
                    }
                    else MenuItems = null;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region "TABS"
        private void ms_AddTab(int ID, string mnuMenu)
        {
            var oItem = Tabs.Where(x => x.Name == mnuMenu);


            if (oItem.Count() == 0)
            {
                Tabs.Add(new modelTabs() { Name = mnuMenu, SimpleContent = _oPlugin.AppMenuAccion(ID), IsSelected = true });
                sTabs = Tabs.Last();
            }
            else
            {
                sTabs = oItem.Last();
            }

        }
        #endregion

        #region "MENU"
        public override void CanExecuteChanged(object sender, object e)
        {
            modelMenuItem oMenu = (modelMenuItem)sender;
            if (oMenu.ID > 0)

            {
                switch (oMenu.ID) 
                {
                    case 2:
                        AppTitle = string.Empty;
                        AppIcon = PackIconKind.Apps;
                        _IHostBuilder = null;
                        _IHost = null;
                        MenuItems.Clear();// = null;
                        Tabs.Clear();
                        HostingServices();
                        Loader();
                        var mnuMain = Application.Current.MainWindow.FindChild<Menu>("mnuMain");
                        mnuMain.Items.Refresh();
                        //var tabMain = Application.Current.MainWindow.FindChild<Dragablz.TabablzControl>("tabMain");
                        //tabMain.Items.Refresh();
                        break;
                    case 3:
                        Application.Current.MainWindow.Close();
                        break;                    
                    default:                
                        ms_AddTab(oMenu.ID, oMenu.Header);
                        break;
            
                }
            }
        }
        private void FindMenuItem(int ID, ObservableCollection<modelMenuItem> oMenuItem)
        {
            try
            {

                var oItem = oMenuItem.Where(x => x.ID == ID).FirstOrDefault();

                if (oItem != null)
                {
                    oItem.Visible = Visibility.Visible;
                    return;

                }
                else
                {
                    foreach (var omnuItem in oMenuItem)
                    {
                        if (omnuItem.MenuItems != null)
                        {
                            FindMenuItem(ID, omnuItem.MenuItems);
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
        }
        #endregion



    }
}
