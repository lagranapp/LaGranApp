using LaGranAppBLL.Modulos.Usuarios;
using LaGranAppCAS.Helpers;
using LaGranAppCAS.Security;
using LaGranAppDAL.Model.Usuario;
using LaGranAppUI.ViewModel.Helpers;
using LaGranAppUI.ViewModel.Snackbar;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LaGranAppUI.ViewModel.Modulos.Usuarios
{
    public class viewmodelUsuarios : viewmodelBase, IviewmodelUsuarios
    {
        #region "Propiedades"
        private readonly IPlugin _plugin;        
        private readonly IBLLUsuarios _usuario;
        private readonly IBLLUsuariosRoles _usuarioRoles;
        private readonly ICASAuthenticationService _authenticationService;
        private readonly ILogger<viewmodelUsuarios> _logger;
        private readonly IviewmodelSnackbar _snackbar;
        private lgaUsuarios _lgaUsuario;
        private bool _PasswordChanged = false;

        
        public int Id
        {
            get { return _lgaUsuario.Id; }
            set
            {
                if (value > 0) _lgaUsuario = _usuario.Read(value);
                else _lgaUsuario = new lgaUsuarios() {Id=0 };

            }
        }
        public string Usuario
        {
            get { return _lgaUsuario.Usuario; }
            set { _lgaUsuario.Usuario = value; }
        }        

        public bool UsuarioRO
        {
            get
            {
                if (_lgaUsuario.Id > 0) return true;
                else return false;
            }
        }

        private string _ClaveVisible;

        public string ClaveVisible
        {
            get {
                if (Id > 0) return "Hidden";
                else return "Visible";
                 }
            set { _ClaveVisible = value;
                OnPropertyChanged("ClaveVisible");
            }
        }


        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set
            {
                if (value.Length > 0) { _Clave = value; _PasswordChanged = true; }
                else _PasswordChanged = false;
                OnPropertyChanged("Clave");
            }
        }

        private string _ClaveVer;

        public string ClaveVer
        {
            get { return _ClaveVer; }
            set { _ClaveVer = value; }
        }

        public string Email
        {
            get { return _lgaUsuario.Email; }
            set { _lgaUsuario.Email = value; }
        }

        public string[] Roles
        {

            get {
                 return _plugin.AppRoles;
                }
        }

        private string _sRole;

        public string sRole
        {
            get { return _sRole; }
            set { _sRole = value; }
        }

        public List<lgaUsuariosRoles> UsuariosRoles
        {
            get
            {
                return _usuarioRoles.List(_plugin.AppId, Usuario);
            }
        }

        public object BoundMessage
        {
            get
            {
                return _snackbar.BoundMessageQueue;
            }
        }

        #endregion

        public viewmodelUsuarios(IPlugin Plugin, IBLLUsuarios Usuario, IBLLUsuariosRoles usuarioRoles, 
            ICASAuthenticationService AuthenticationService, ILogger<viewmodelUsuarios> logger, IviewmodelSnackbar snackbar)
        {
            try
            {
                _plugin = Plugin;                
                _usuario = Usuario;
                _usuarioRoles = usuarioRoles;
                _authenticationService = AuthenticationService;
                _logger = logger;
                _snackbar = snackbar;
                _lgaUsuario = new lgaUsuarios();
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
                lgaUsuariosRoles oData;
                switch (sender)
                {
                    case "AnadirRole":
                        if (Id > 0)
                        {
                            oData = new lgaUsuariosRoles() { UsuarioId = Id, RoleId = sRole };
                            if (_usuarioRoles.Create(oData)) OnPropertyChanged("UsuariosRoles");
                        }
                        else
                        {
                            _snackbar.Message = "Requiere guardar el usuario y luego adicionar los roles.";
                        }                        
                        break;
                    case "Guardar":
                        _lgaUsuario.AppId = _plugin.AppId.ToString();
                        if (_PasswordChanged)
                        {
                            if(Clave!=ClaveVer)
                            {
                                _snackbar.Message = "La contraseña y su verificación es incorrecta. Favor verifique.";
                                break;
                            }
                            _lgaUsuario.Clave = _authenticationService.CalculateHash(Clave, _lgaUsuario.Usuario);

                        }
                        if (Id == 0)
                        {
                            if (_usuario.Create(_lgaUsuario))
                            {
                                ClaveVisible = "Hidden";
                                _snackbar.Message = "Registro guardado exitosamente!";
                            }
                            else _snackbar.Message = "No se logro guardar el registro. Favor verifique.";
                        }
                        else
                        {

                            if (_usuario.Update(_lgaUsuario)) _snackbar.Message = "El registro se actualizo exitosamente!";
                            else _snackbar.Message = "No se logro actualizar el registro. Favor verifique.";
                        }
                      
                        
                        break;
                    case "Eliminar":
                        if (Id > 0)
                        {
                            if (_usuario.Delete(_lgaUsuario))
                            {
                                _snackbar.Message = "Registro eliminado exitosamente.";
                                New();
                            }
                            else _snackbar.Message = "No se logro eliminar el registro.";
                        }
                        break;
                    case "Nuevo":                        
                        New();
                        break;
                    default:

                        oData = _usuarioRoles.Read(int.Parse(sender.ToString()));
                        if (_usuarioRoles.Delete(oData)) OnPropertyChanged("UsuariosRoles");
                        break;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                _snackbar.Message = ex.Message;
            }
        }

        private void New()
        {
            try
            {
                Id = 0; 
                _lgaUsuario = new lgaUsuarios();
                Clave = string.Empty;
                ClaveVer = string.Empty;
                ClaveVisible = "Visible";
                OnPropertyChanged(string.Empty);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
