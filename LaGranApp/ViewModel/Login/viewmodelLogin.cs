using LaGranAppCAS.Helpers;
using LaGranAppCAS.Security;
using LaGranAppUI.ViewModel.Helpers;
using LaGranAppUI.ViewModel.Snackbar;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace LaGranApp.ViewModel.Login
{
    public class viewmodelLogin : viewmodelBase
    {
        private readonly IviewmodelSnackbar _snackbar;
        private readonly ILogger<viewmodelLogin> _logger;
        private readonly IPlugin _plugin;

        public string usuario { get; set; }
        public bool Autenticado { get; set; }
        private ICASAuthenticationService _AuthenticationService { get; }

        public viewmodelLogin(ICASAuthenticationService authenticationService, IviewmodelSnackbar snackbar, ILogger<viewmodelLogin> logger, IPlugin plugin) 
        {
            this._AuthenticationService = authenticationService;
            _snackbar = snackbar;
            _logger = logger;
            _plugin = plugin;
        }        

        public override void CanExecuteChanged(object sender, object e)
        {
            
            try
            {
                PasswordBox passwordBox = sender as PasswordBox;
                string clearTextPassword = passwordBox.Password;
                Username = usuario;
                CASUser oUser = _AuthenticationService.AuthenticateUser(usuario, clearTextPassword);
                CASCustomPrincipal customPrincipal = Thread.CurrentPrincipal as CASCustomPrincipal;
                customPrincipal.Identity = new CASCustomIdentity(oUser.Username, oUser.Email, oUser.Roles);
                

                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    _logger.LogInformation("Usuario autenticado", "Usuario: " + oUser.Username, "App: " + _plugin.AppNombre , "App Id: " + _plugin.AppId.ToString());
                    Application.Current.MainWindow.OwnedWindows[Application.Current.MainWindow.OwnedWindows.Count - 1].Close();
                }

            }
            catch
            {
                _snackbar.Message = "Usuario o clave incorrecta !";
                _logger.LogWarning("Intento fallido de login", "Usuario: " + usuario, "App: " + _plugin.AppNombre, "App Id: " + _plugin.AppId.ToString());
                // throw;
            }
        }



    }
}
