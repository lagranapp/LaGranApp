using LaGranAppCAS.Helpers;
using QLicense;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace LaGranApp.ViewModel.Activacion
{
    public class viewmodelActivacion : LaGranAppUI.ViewModel.Helpers.viewmodelBase, IviewmodelActivacion
    {
        public delegate void evntValidate(string valor);
        public event evntValidate evnValidate;
        #region "Propiedades"
        public LicenseStatus LICENSESTATUS { get; set; } = LicenseStatus.UNDEFINED;
        public bool ShowMessageAfterValidation { get; set; }
        private string _CodigoMaquina;
        public string CodigoMaquina
        {
            get { return _CodigoMaquina; }
            set { _CodigoMaquina = value; OnPropertyChanged("CodigoMaquina"); }
        }
        private string _CodigoActivacion;
        private readonly IPlugin _plugin;

        public string CodigoActivacion
        {
            get { return _CodigoActivacion; }
            set 
            { 
                _CodigoActivacion = value;
                OnPropertyChanged("CodigoActivacion"); 
            }
        }

        public byte[] CertifcatePublicKeyData
        {
            get
            {
                using (MemoryStream _mem = new MemoryStream())
                {
                    AppLicense.CopyTo(_mem);

                    return _mem.ToArray();
                }
            }
        }
        public Stream AppLicense { get; set; }
        public string AppLicFileName { get; set; }

        public string AppTitleName { get; set; }

        public string AppName { get; set; }
        public Type LicenseObjectType
        {
            get
            {
                return typeof(MyLicense);
            }
        }
        #endregion

        public viewmodelActivacion(IPlugin plugin)
        {
            try
            {
                _plugin = plugin;
                CodigoMaquina = LicenseHandler.GenerateUID(_plugin.AppNombre);
            }
            catch
            {
                throw;
            }
         
        }



        public override void CanExecuteChanged(object sender, object e)
        {
            try
            {
                switch (sender)
                {
                    case "Guardar":
                        string strCadena = CipherHelper.Encrypt(CodigoActivacion, "2018");
                        ValidateLicense();
                        break;
                    case "Nuevo":
                        CodigoActivacion  = string.Empty;
                        break;
                }
            }
            catch
            {
                throw;
            }
        }
        #region "HELPERS"
        public Stream Read(string strLicenseNameWithNameSpace, bool License = true)
        {
            try
            {
                System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetCallingAssembly();
                return myAssembly.GetManifestResourceStream(strLicenseNameWithNameSpace);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ValidateLicense()
        {
            LicenseStatus _licStatus = LicenseStatus.UNDEFINED;

            if (string.IsNullOrWhiteSpace(CodigoActivacion))
            {              
                return;
            }

            //Check the activation string
            
            string _msg = string.Empty;
            QLicense.AppName.AppNombre = _plugin.AppNombre;
            LicenseEntity _lic = LicenseHandler.ParseLicenseFromBASE64String(LicenseObjectType, CodigoActivacion.Trim(), CertifcatePublicKeyData, out _licStatus, out _msg);
            LICENSESTATUS = _licStatus;
            switch (_licStatus)
            {
                case LicenseStatus.VALID:
                    if(!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAGRANAPP")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAGRANAPP"));
                    }
                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LAGRANAPP", _plugin.AppLicFileName ), CodigoActivacion);
                    if (ShowMessageAfterValidation)
                    {
                        evnValidate(CodigoActivacion);                       

                    }

                    Application.Current.MainWindow.OwnedWindows[Application.Current.MainWindow.OwnedWindows.Count - 1].Close();

                    return;

                case LicenseStatus.CRACKED:
                case LicenseStatus.INVALID:
                case LicenseStatus.UNDEFINED:
                    if (ShowMessageAfterValidation)
                    {                       

                    }

                    return;

                default:
                    return;
            }
        }
        #endregion
    }
}
