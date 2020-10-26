using LaGranAppCAS.Security;
using LaGranAppUI.Model.Menu;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;

namespace LaGranAppPlugin
{
    public interface IPlugin
    {                
        string AppNombre { get; set; }
        ObservableCollection<modelMenuItem> AppMenu { get; set; }
        System.Windows.Controls.UserControl AppMenuAccion(int ID);
        //MaterialDesignThemes.Wpf.PackIcon AppIco { get; set; }
        MaterialDesignThemes.Wpf.PackIconKind AppIco { get; set; }
        bool AppReqMantUsuarios { get; set; }
        bool AppReqLicense { get; set; }
        Stream AppLicense { get; set; }
        string AppLicFileName { get; set; }
        IHost AppIHost { get; set; }      
        IHostBuilder AppIHostBuilder { get; set; }
        Guid AppId { get; set; }
        string[] AppRoles { get; set; }
        
    }
}
