using System.Collections.Generic;
using System.Diagnostics;

namespace LaGranAppUI.ViewModel.Mantenimiento.Bitacora
{
    public interface IviewmodelBitacora
    {
        IEnumerable<EventLogEntry> Bitacora { get; set; }
    }
}