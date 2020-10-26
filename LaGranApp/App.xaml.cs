using LaGranApp.View.Main;
using LaGranApp.ViewModel.Main;
using LaGranAppCAS.Security;
using LaGranAppDAL.Context;
using LaGranAppDAL.Model.Config;
using LaGranAppDAL.CRUD;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Hosting;
using LaGranAppBLL.Modulos.Configuracion;
using Microsoft.EntityFrameworkCore;
using LaGranAppDAL.Model.Menu;
using LaGranAppDAL.Model.Usuario;
using System.Diagnostics;

namespace LaGranApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {     
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CASCustomPrincipal customPrincipal = new CASCustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);           

            //var myService = Provider.GetService<LaGranAppBLL.Entidades.Configuracion.IConfiguracion>();
           /* IConfiguracion myService = ActivatorUtilities.CreateInstance<Configuracion>(_Host.Services);
            lgaConfig olgaConfig = myService.Read(new lgaConfig() { Id = 1 });*/
            viewMain wnd = new viewMain();
            wnd.Show();
            wnd.DataContext = new viewmodelMain();
            //wnd.DataContext = new viewmodelMain(new AuthenticationService(), Provider);
            //wnd.DataContext = ActivatorUtilities.CreateInstance<AuthenticationService>(_Host.Services);

        }
    }
}
