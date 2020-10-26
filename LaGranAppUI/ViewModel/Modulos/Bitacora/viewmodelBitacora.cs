using LaGranAppUI.ViewModel.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LaGranAppUI.ViewModel.Mantenimiento.Bitacora
{
    public class viewmodelBitacora : viewmodelBase, IviewmodelBitacora
    {
        private IEnumerable<EventLogEntry> _Bitacora;
        private readonly ILogger<viewmodelBitacora> _logger;
        private int _PageIndex=1;
        private EventLog _log;

        public IEnumerable<EventLogEntry> Bitacora
        {
            get { return _Bitacora; }
            set 
            { 
                _Bitacora = value;
                OnPropertyChanged("Bitacora");
            }
        }

        public viewmodelBitacora(ILogger<viewmodelBitacora> logger)
        {
            try
            {
                _log = new EventLog("Application");
                _logger = logger;
                FillGrid();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

        }

        private void FillGrid()
        {
            try
            {                
                Bitacora = _log.Entries.Cast<EventLogEntry>().Where(x => x.Source == "LGA").OrderByDescending(d=>d.TimeGenerated).Skip(_PageIndex-1).Take(10);                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }

        public override void CanExecuteChanged(object sender, object e)
        {
            try
            {
                switch (sender)
                {
                    
                    case "Primero":                        
                        FillGrid();
                        break;
                    case "Previo":
                        if (_PageIndex > 1) { _PageIndex -= 1; FillGrid(); }
                        break;
                    case "Siguiente":
                        _PageIndex += 1;
                        FillGrid();
                        break;
                    default:
                     
                        FillGrid();
                        break;

                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
