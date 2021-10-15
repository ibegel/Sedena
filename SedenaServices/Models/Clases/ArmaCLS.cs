using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ArmaCLS
    {
        public int idArma { get; set; }
        public string nombre { get; set; }
        public string caracteristicas{ get; set; }
        public ArmaCLS(int idArma,string nombre, string caracteristicas) 
        {
            this.idArma = idArma;
            this.nombre = nombre;
            this.caracteristicas = caracteristicas;
        }
        public ArmaCLS()
        {
        }
    }
}