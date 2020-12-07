using AppDemo.View.Mantenimiento.Usuarios;
using LaGranAppPlugin;
using LaGranAppUI.View.Modulos.Bitacora;
using LaGranAppUI.View.Modulos.MenuRoles;
using LaGranAppUI.ViewModel.Mantenimiento.Bitacora;
using LaGranAppUI.ViewModel.Modulos.MenuRoles;
using LaGranAppUI.ViewModel.Modulos.Usuarios;
using LaGranAppUI.Model.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using AppDemo.View.Mantenimiento.Bitacora;
using LaGranAppDAL.CRUD;
using AppDemo.BLL.Contar;
using AppDemo.Model.Contar;
using AppDemo.DAL.Contar;
using AppDemo.ViewModel.Procesos.Contar;
using AppDemo.View.Procesos.Contar;
using AppDemo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppDemo
{
    public class Main : Plugin, IPlugin
    {
        public new string AppNombre
        {
            get
            {
                return "Aplicación demo";
            }
            set
            {

            }
        }
        public new ObservableCollection<modelMenuItem> AppMenu
        {
            get
            {
                ObservableCollection<modelMenuItem> MenuItems = new ObservableCollection<modelMenuItem>
            {
                new modelMenuItem { Header = "Archivo" , ID=1,
                    MenuItems = new ObservableCollection<modelMenuItem>
                    {
                        new modelMenuItem { Header = "Cerrar sesión", Icon =new MaterialDesignThemes.Wpf.PackIcon(){Kind= MaterialDesignThemes.Wpf.PackIconKind.Logout }, ID=2 },
                        new modelMenuItem { Header = "Salir", Icon =new MaterialDesignThemes.Wpf.PackIcon(){Kind= MaterialDesignThemes.Wpf.PackIconKind.ExitRun }, ID=3 }
                    }
                
                
                },
                new modelMenuItem { Header = "Mantenimiento", ID=19,
                    MenuItems = new ObservableCollection<modelMenuItem>
                        {
                            new modelMenuItem { Header = "Usuarios", Icon =new MaterialDesignThemes.Wpf.PackIcon(){Kind= MaterialDesignThemes.Wpf.PackIconKind.Users }, ID=20 },
                            new modelMenuItem { Header = "Bitacora", Icon =new MaterialDesignThemes.Wpf.PackIcon(){Kind= MaterialDesignThemes.Wpf.PackIconKind.FileDocument }, ID=22 },
                            new modelMenuItem { Header = "Productos",
                                MenuItems = new ObservableCollection<modelMenuItem>
                                {
                                    new modelMenuItem { Header = "Beta1a"  },
                                    new modelMenuItem { Header = "Beta1b" },
                                    new modelMenuItem { Header = "Beta1c" }
                                }
                            },
                            new modelMenuItem { Header = "Menus" ,Icon = new MaterialDesignThemes.Wpf.PackIcon(){Kind = MaterialDesignThemes.Wpf.PackIconKind.Menu }, ID=21 }
                        }
                },
                new modelMenuItem 
                { 
                    Header = "Procesos" ,ID=30,                
                    MenuItems = new ObservableCollection<modelMenuItem>                                        
                    {
                            new modelMenuItem { Header = "Contar", Icon =new MaterialDesignThemes.Wpf.PackIcon(){Kind= MaterialDesignThemes.Wpf.PackIconKind.Calculator }, ID=31 }
                    } 
                } 
            };
                return MenuItems;
            }
            set
            {

            }
        }

        public MaterialDesignThemes.Wpf.PackIconKind AppIco
        {
            get
            {
                //return new MaterialDesignThemes.Wpf.PackIcon() { Kind = MaterialDesignThemes.Wpf.PackIconKind.Users };
                return MaterialDesignThemes.Wpf.PackIconKind.Users;
            }
            set
            {

            }
        }

        public new bool AppReqMantUsuarios { get => true; set => throw new NotImplementedException(); }
       
        public new Stream AppLicense
        {
            get
            {
                return Read("AppDemo.LAGRANAPP.cer");
            }
            set => throw new NotImplementedException(); }
        public new bool AppReqLicense { get => true; set => throw new NotImplementedException(); }
        public new string AppLicFileName { get
            {
                return "AppDemo.lic";
            }
            set => throw new NotImplementedException(); }
        public new IHost AppIHost { get; set; }
        public new IHostBuilder AppIHostBuilder
        {
            get
            {
                return null;
            }

            set
            {
                value.ConfigureServices((context, services)=>{
                    #region DAL"
                    services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));
                    services.AddTransient<IDALContar,DALContar>();
                    #endregion

                    #region "BLL"
                    services.AddTransient<IBLLContar, BLLContar>();
                    #endregion

                    #region "UI"
                    services.AddTransient<IviewmodelContar, viewmodelContar>();
                    #endregion

                });
            }
        }
        public new Guid AppId { get => Guid.Parse("c558b62d-a9fe-40a3-aaf7-e49ab55135cd"); set => throw new NotImplementedException(); }
        public new string[] AppRoles { 
            get {
                return new string[]{"Administrador", "Editor" };
            } set => throw new NotImplementedException(); }

        public new UserControl AppMenuAccion(int ID)
        {
            try
            {                
                switch (ID)
                {
                    case 20:
                        var view = new viewUsuariosList();
                        view.DataContext = ActivatorUtilities.CreateInstance<viewmodelUsuariosList>(AppIHost.Services);
                        return view;
                    case 21:
                        var view2 = new viewMenuRoles();
                        view2.DataContext = ActivatorUtilities.CreateInstance<viewmodelMenuRoles>(AppIHost.Services);
                        return view2;
                    case 22:
                        var view3 = new viewMantBitacora();
                        view3.DataContext = ActivatorUtilities.CreateInstance<viewmodelBitacora>(AppIHost.Services);
                        return view3;
                    case 31:
                        var view4 = new viewContar();
                        view4.DataContext = ActivatorUtilities.CreateInstance<viewmodelContar>(AppIHost.Services);
                        return view4;
                    default:
                        return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
