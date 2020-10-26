using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LaGranAppCAS.Security
{
    public class CASCustomPrincipal : IPrincipal
    {
        private CASCustomIdentity _identity;

        public CASCustomIdentity Identity
        {
            get { return _identity ?? new CASAnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }
        #endregion
    }
}
