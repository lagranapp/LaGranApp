using Microsoft.Extensions.Hosting;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace LaGranAppCAS.Helpers
{
    public interface IPlugin
    {
        object AppIco { get; set; }
        Guid AppId { get; set; }
        Stream AppLicense { get; set; }
        string AppLicFileName { get; set; }
        string AppNombre { get; set; }
        bool AppReqLicense { get; set; }
        bool AppReqMantUsuarios { get; set; }
        object AppMenu { get; set; }
        string[] AppRoles { get; set; }
    }
}