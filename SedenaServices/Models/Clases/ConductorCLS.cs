using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ConductorCLS
    {
        public int id_Funcion { get; set; }
        public int id_Vehiculo { get; set; }
        public string posicion { get; set; }
        public string anomalia { get; set; }

    }
}