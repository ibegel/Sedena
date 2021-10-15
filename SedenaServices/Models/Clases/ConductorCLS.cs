using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ConductorCLS
    {
        public int idFuncion { get; set; }
        public int idVehiculo { get; set; }

        public ConductorCLS()
        {
            
        }
        public ConductorCLS(int id_Funcion,int id_Vehiculo)
        {
            this.idFuncion = id_Funcion;
            this.idVehiculo = id_Vehiculo;
        }
    }
}