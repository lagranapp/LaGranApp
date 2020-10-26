using AppDemo.BLL.Contar;
using AppDemo.Model.Contar;
using LaGranAppUI.ViewModel.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.ViewModel.Procesos.Contar
{
    public class viewmodelContar : viewmodelBase, IviewmodelContar
    {
        private int _Contador;
        private readonly ILogger<viewmodelContar> _logger;
        private readonly IBLLContar _bLLContar;

        public int Contador
        {
            get 
            {                     
                _modelContar =_bLLContar.Read(1);
                return _modelContar.Contador;
            }
            set { _Contador = value; OnPropertyChanged("Contador"); }
        }

        private AppContar _modelContar;

        public AppContar modelContar
        {
            get { return _modelContar; }
            set { _modelContar = value; }
        }


        public viewmodelContar(ILogger<viewmodelContar> logger, IBLLContar bLLContar)
        {
            _logger = logger;
            _bLLContar = bLLContar;
        }

        public override void CanExecuteChanged(object sender, object e)
        {
            try
            {
                if (_bLLContar.Update(_modelContar))
                {
                    _modelContar.Contador = _bLLContar.Read(1).Contador;
                    Contador = _modelContar.Contador;
                }

            }
            catch
            {

            }
        }
    }
}
