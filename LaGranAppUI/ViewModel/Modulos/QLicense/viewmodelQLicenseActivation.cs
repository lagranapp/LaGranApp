using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using QLicense;

namespace LaGranAppUI.ViewModel.Modulos.QLicense
{
    public class viewmodelQLicenseActivation : Helpers.viewmodelBase
    {
        public delegate void evntValidate(string valor);
        public event evntValidate evnValidate;
        #region "Propiedades"
        public bool ShowMessageAfterValidation { get; set; }
        private string _CodigoMaquina;
        public string CodigoMaquina
        {
            get { return _CodigoMaquina; }
            set { _CodigoMaquina = value; OnPropertyChanged("CodigoMaquina"); }
        }
        private string _CodigoActivacion;
        public string CodigoActivacion
        {
            get { return _CodigoActivacion; }
            set { _CodigoActivacion = value; OnPropertyChanged("CodigoActivacion"); }
        }

        public byte[] CertifcatePublicKeyData 
        {
            get 
            {
                using (MemoryStream _mem = new MemoryStream())
                {
                    Read("LaGranAppUI.LaGranApp.cer", true).CopyTo(_mem);

                    return _mem.ToArray();
                }
            }
        }

        public string AppLicFileName { get; set; }

        public Stream AppLicense { get; set; }

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

        public viewmodelQLicenseActivation()
        {
            try
            {
                CodigoMaquina = LicenseHandler.GenerateUID(AppName);
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
                        string strCadena = CipherHelper.Encrypt(CodigoActivacion, "2018");  // StringCipher.Encrypt(CodigoActivacion, "2018");
                        ValidateLicense();
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
        public bool ValidateLicense()
        {


            if (string.IsNullOrWhiteSpace(CodigoActivacion))
            {
                // MessageBox.Show("Please input license", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Check the activation string
            LicenseStatus _licStatus = LicenseStatus.UNDEFINED;
            string _msg = string.Empty;
            LicenseEntity _lic = LicenseHandler.ParseLicenseFromBASE64String(LicenseObjectType, CodigoMaquina.Trim(), CertifcatePublicKeyData, out _licStatus, out _msg);

            switch (_licStatus)
            {
                case LicenseStatus.VALID:
                    if (ShowMessageAfterValidation)
                    {
                        evnValidate(CodigoActivacion);

                        //this.Controls.Add(new Literal() { Text = "<div style='width:100%;text-align:center'><h3>Licencia valida !</h3></p>" });


                        // LicenseInfo oLicInf = new LicenseInfo();

                        // this.Controls.Add(new Literal() { Text = "<h3>" + oLicInf.ShowLicenseInfo(_lic, "Cantidad de usuarios") +"</h3>" });

                    }

                    return true;

                case LicenseStatus.CRACKED:
                case LicenseStatus.INVALID:
                case LicenseStatus.UNDEFINED:
                    if (ShowMessageAfterValidation)
                    {
                       // this.Controls.Add(new Literal() { Text = "<div style='width:100%;text-align:center'><h3>Licencia invalida !</h3></p>" });

                    }

                    return false;

                default:
                    return false;
            }
        }
        #endregion

    }
}
