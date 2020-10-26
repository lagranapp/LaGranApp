using LaGranAppCAS.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace LaGranAppUI.ViewModel.Helpers
{
    public abstract class viewmodelBase : INotifyPropertyChanged , IviewmodelBase
    {

        #region "Propiedades"
        private string _username;        
        public virtual bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }
        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        #endregion

        #region "Login/Logout"

        public virtual void Login(object parameter)
        {
            try
            {
                /*User user = _authenticationService.AuthenticateUser(Username, parameter.ToString());
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);*/
            }
            catch (UnauthorizedAccessException)
            {

            }
        }


        private void Logout(object parameter)
        {
            CASCustomPrincipal customPrincipal = Thread.CurrentPrincipal as CASCustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new CASAnonymousIdentity();
            }
        }
        #endregion


        public viewmodelBase()
        {


        }

        #region "Command"

        private ICommand _Command;
        public ICommand Command
        {
            get
            {
                if (_Command == null)
                {
                    _Command = new cCommand();
                    _Command.CanExecuteChanged += CanExecuteChanged;

                }
                return _Command;
            }
        }

        public virtual void CanExecuteChanged(object sender, object e)
        {
            try
            {

                switch (sender)
                {

                    default:
                        break;

                }


            }
            catch
            {
                throw;
            }
        }
        private class cCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                try
                {

                    CanExecuteChanged.Invoke(parameter, new EventArgs());
                }
                catch
                {
                    throw;
                }

            }
        }
        #endregion

        #region Notify"
        #region INotifyPropertyChanged Members  
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
