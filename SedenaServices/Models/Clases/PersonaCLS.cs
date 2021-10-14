using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class PersonaCLS
    {
        public int id_Encargado { get; set; }
        public string tipo_Encargado { get; set; }
        public string pass { get; set; }
        public int id_Agente { get; set; }
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string distintivo { get; set; }
        public string arma { get; set; }
        public int existencia {get; set;}

        public PersonaCLS() 
        {

        }
}
}