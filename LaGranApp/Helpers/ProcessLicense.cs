using LaGranAppCAS.Helpers;
using QLicense;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LaGranApp.Helpers
{
    public class ProcessLicense : IProcessLicense
    {
        private readonly IPlugin _plugin;
        public byte[] _certPubicKeyData;
        private Stream strLicense;
        private string strAppName, strLICFileName;
        public ProcessLicense(IPlugin plugin)
        {
            try
            {
                _plugin = plugin;
                strLicense = _plugin.AppLicense;
                strAppName = _plugin.AppNombre;
                strLICFileName = _plugin.AppLicFileName;
            }
            catch
            {
                throw;
            }

        }
        public LicenseStatus Process() //, Form oParent)
        {
            try
            {
                MyLicense _lic = null;
                string _msg = string.Empty;                
                LicenseStatus _status = LicenseStatus.UNDEFINED;               

                if (strLicense != null)
                {
                    using (MemoryStream _mem = new MemoryStream())
                    {
                        strLicense.CopyTo(_mem);
                        _certPubicKeyData = _mem.ToArray();
                    }

                    if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAGRANAPP", strLICFileName)))
                    {
                        _lic = (MyLicense)LicenseHandler.ParseLicenseFromBASE64String(
                            typeof(MyLicense),
                            File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAGRANAPP", strLICFileName)),
                            _certPubicKeyData,
                            out _status,
                            out _msg);

                    }
                    else
                    {
                        _status = LicenseStatus.INVALID;
                        _msg = "Este módulo no ha sido activado !";
                    }
                }
                return _status;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
