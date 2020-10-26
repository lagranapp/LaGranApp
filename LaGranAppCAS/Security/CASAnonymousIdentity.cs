using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaGranAppCAS.Security
{
    public class CASAnonymousIdentity : CASCustomIdentity
    {
        public CASAnonymousIdentity()
            : base(string.Empty, string.Empty, new string[] { })
        { }
    }
}
