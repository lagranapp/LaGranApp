using System;
using System.IO;

namespace LaGranApp.ViewModel.Activacion
{
    public interface IviewmodelActivacion
    {
        string AppLicFileName { get; set; }
        string AppName { get; set; }
        string AppTitleName { get; set; }
        byte[] CertifcatePublicKeyData { get; }
        string CodigoActivacion { get; set; }
        string CodigoMaquina { get; set; }
        Type LicenseObjectType { get; }
        bool ShowMessageAfterValidation { get; set; }

        event viewmodelActivacion.evntValidate evnValidate;

        void CanExecuteChanged(object sender, object e);
        Stream Read(string strLicenseNameWithNameSpace, bool License = true);
        void ValidateLicense();
    }
}