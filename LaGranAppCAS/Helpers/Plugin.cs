using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace LaGranAppCAS.Helpers
{
    public class Plugin : IPlugin
    {
        private static Guid _AppId;
        private static object _AppIco;
        private static bool _AppReqMantUsuarios;
        private static bool _AppReqLicense;
        private static Stream _AppLicense;
        private static string _AppLicFileName;
        private static string _AppNombre;
        private static object _AppMenu;
        private static string[] _AppRoles;

        public string AppNombre {get => _AppNombre;set{ _AppNombre = value; } }

        public bool AppReqMantUsuarios
        {
            get => _AppReqMantUsuarios; set { _AppReqMantUsuarios = value; }
        }
        public bool AppReqLicense { get => _AppReqLicense; set { _AppReqLicense = value; } }
        public Stream AppLicense { get => _AppLicense; set { _AppLicense = value; } }
        public string AppLicFileName { get => _AppLicFileName; set { _AppLicFileName = value; } }
        public Guid AppId { get => _AppId; set { _AppId = value; } }

        public object AppIco
        {
            get => _AppIco;
            set
            {
                _AppIco = value;
            }
        }

        public object AppMenu { get=>_AppMenu; set { _AppMenu = value; } }

        public string[] AppRoles { get => _AppRoles; set { _AppRoles = value; } }
    }
}
