using AppDemo.DAL.Contar;
using AppDemo.Model.Contar;
using LaGranAppDAL.CRUD;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDemo.BLL.Contar
{
    public class BLLContar : IBLLContar
    {
        private readonly IDALContar _dALContar;

        public BLLContar(IDALContar dALContar )
        {
            
            _dALContar = dALContar;
        }


        

        public AppContar Read(int Id)
        {
            return _dALContar.Read(Id);
        }

        public bool Update(AppContar Entidad)
        {
            Entidad.Id = 1;
            Entidad.Contador += 1;
            return _dALContar.Update(Entidad);
        }
    }
}
