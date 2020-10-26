using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QLicense
{
    public enum LicenseTypes
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Single")]
        Single = 1,
        [Description("Volume")]
        Volume = 2
    }
}
