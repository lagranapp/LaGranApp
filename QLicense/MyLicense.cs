using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace QLicense
{
    public class MyLicense :LicenseEntity
    {
        [DisplayName("Balance Inicial")]
        [Category("License Options")]
        [XmlElement("EnableFeature01")]
        [ShowInLicenseInfo(true, "Balance Inicial", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool BalanceInicial { get; set; }

        [DisplayName("Linea de Credito Multiple")]
        [Category("License Options")]
        [XmlElement("EnableFeature02")]
        [ShowInLicenseInfo(true, "Linea Credito Multiple", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool LineaCreditoMultiple { get; set; }


        [DisplayName("Restructuración de Plan de Pago")]
        [Category("License Options")]
        [XmlElement("EnableFeature03")]
        [ShowInLicenseInfo(true, "Restructuracion", ShowInLicenseInfoAttribute.FormatType.String)]
        public bool RestructuracionPlanPago { get; set; }

        [DisplayName("Cantidad de usuarios")]
        [Category("License Options")]
        [XmlElement("EnableFeature04")]
        [ShowInLicenseInfo(true, "Cantidad de usuarios", ShowInLicenseInfoAttribute.FormatType.String)]
        public int CantidadUsuarios { get; set; }


        [DisplayName("Fecha de Expiración")]
        [Category("License Options")]
        [XmlElement("EnableFeature05")]
        [ShowInLicenseInfo(true, "Fecha de Expiracion", ShowInLicenseInfoAttribute.FormatType.String)]
        public string FechaExpiracion { get; set; }



        public MyLicense()
        {
            //Initialize app name for the license
            this.AppName = QLicense.AppName.AppNombre; //"LAGRANAPP";
        }

        public override LicenseStatus DoExtraValidation(out string validationMsg)
        {
            LicenseStatus _licStatus = LicenseStatus.UNDEFINED;
            validationMsg = string.Empty;

            switch (this.Type)
            {
                case LicenseTypes.Single:
                    //For Single License, check whether UID is matched
                    if (this.UID == LicenseHandler.GenerateUID(this.AppName))
                    {
                        _licStatus = LicenseStatus.VALID;
                    }
                    else
                    {
                        validationMsg = "Esta licencia no es para esta copia !";
                        _licStatus = LicenseStatus.INVALID;
                    }
                    break;
                case LicenseTypes.Volume:
                    //No UID checking for Volume License
                    _licStatus = LicenseStatus.VALID;
                    break;
                default:
                    validationMsg = "Licencia invalida !";
                    _licStatus = LicenseStatus.INVALID;
                    break;
            }

            return _licStatus;
        }
    }
}
