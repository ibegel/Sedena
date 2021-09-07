using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ArmaCLS
    {
        public int id_Arma { get; set; }
        public string nombre { get; set; }
        public string caracteristicas{ get; set; }
        public ArmaCLS(int id_Arma,string nombre, string caracteristicas) 
        {
            this.id_Arma = id_Arma;
            this.nombre = nombre;
            this.caracteristicas = caracteristicas;
        }
        public ArmaCLS()
        {
        }
    }
}