using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class DisparoCLS
    {
        public int id_Funcion { get; set; }
        public int id_Arma { get; set; }
        public string puntuacion { get; set; }
        public string anomalias { get; set; }
    }
}