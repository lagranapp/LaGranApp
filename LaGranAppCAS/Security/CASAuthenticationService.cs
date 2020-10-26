using LaGranAppBLL.Modulos.Usuarios;
using LaGranAppCAS.Helpers;
using LaGranAppDAL.Model.Usuario;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LaGranAppCAS.Security
{

    public class CASAuthenticationService : ICASAuthenticationService
    {
        private readonly IBLLUsuarios _usuarios;
        private IBLLUsuariosRoles _UsuariosRoles;
        private IPlugin _Plugin;
        public CASAuthenticationService(IBLLUsuarios Usuarios,IBLLUsuariosRoles UsuariosRoles, IPlugin Plugin)
        {
            _usuarios = Usuarios;
            _UsuariosRoles = UsuariosRoles;
            _Plugin = Plugin;
        }
        private static CASUser _AuthenticatedUser;
        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }
            public string Username
            {
                get;
                private set;
            }

            public string Email
            {
                get;
                private set;
            }

            public string HashedPassword
            {
                get;
                private set;
            }

            public string[] Roles
            {
                get;
                private set;
            }
        }

        private readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("Mark", "mark@company.com",
            "MB5PYIsbI2YzCUe34Q5ZU2VferIoI4Ttd+ydolWV0OE=", new string[] { "Administrators" }),
            new InternalUserData("John", "john@company.com",
            "hMaLizwzOQ5LeOnMuj+C6W75Zl5CXXYbwDSHWW9ZOXc=", new string[] { })
        };

        private List<lgaUsuarios> _Users
        {
            get
            {
                return _usuarios.List(_Plugin.AppId).ToList();
            }   
        }

        public CASUser AuthenticatedUser
        {

            get
            {
                if (_AuthenticatedUser != null) return _AuthenticatedUser;
                else return null;
            }
            
        }

        public CASUser AuthenticateUser(string username, string clearTextPassword)
        {
            /*InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username)
                && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));*/
            
            lgaUsuarios userData = _Users.FirstOrDefault(u => u.Usuario.Equals(username)
            && u.Clave.Equals(CalculateHash(clearTextPassword, u.Usuario)
            ));

            if (userData == null) throw new UnauthorizedAccessException("Acceso denegado.");
            
            _AuthenticatedUser = new CASUser(userData.Usuario, userData.Email, _UsuariosRoles.List(_Plugin.AppId, username).Select(i => i.RoleId.ToString()).ToArray(), userData.Id);
            return _AuthenticatedUser;
        }

        public string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }

       
    }
}
