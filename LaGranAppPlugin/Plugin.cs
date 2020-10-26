using LaGranAppUI.Model.Menu;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace LaGranAppPlugin
{
    public class Plugin : IPlugin
    {
        private static Guid _AppId;
        private static MaterialDesignThemes.Wpf.PackIconKind _AppIco;
        private static bool _AppReqMantUsuarios;
        private static bool _AppReqLicense;
        private static Stream _AppLicense;
        private string _AppLicFileName;
        private static string[] _AppRoles;

        public string AppNombre { get; set; }

        public ObservableCollection<modelMenuItem> AppMenu { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MaterialDesignThemes.Wpf.PackIconKind AppIco
        {
            get => _AppIco;            
            set
            {
                _AppIco = value;
            }
        }

        public bool AppReqMantUsuarios
        {
            get => _AppReqMantUsuarios; set { _AppReqMantUsuarios=value; }
        }
        public bool AppReqLicense { get => _AppReqLicense ; set { _AppReqLicense = value; } }
        public Stream AppLicense { get => _AppLicense; set { _AppLicense = value; } }
        public string AppLicFileName { get => _AppLicFileName; set { _AppLicFileName = value; }}
        public IHost AppIHost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IHostBuilder AppIHostBuilder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public  Guid AppId { get => _AppId; set { _AppId = value; } }

        public string[] AppRoles { get => _AppRoles; set { _AppRoles = value; } }

        public UserControl AppMenuAccion(int ID)
        {
            return null;
        }
    }
}
