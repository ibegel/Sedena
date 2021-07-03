using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class SesionCLS
    {
        public int id_Sesion { get; set; }
        public string tipo_Sesion { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public int id_Encargado { get; set; }
    }
}