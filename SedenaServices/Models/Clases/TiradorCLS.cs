using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class TiradorCLS
    {
        public int id_Funcion { get; set; }
        public int id_Arma { get; set; }
        public TiradorCLS(int id_Funcion, int id_Arma)
        {
            this.id_Funcion = id_Funcion;
            this.id_Arma = id_Arma;
        }

        public TiradorCLS()
        { 
        }
    }
}