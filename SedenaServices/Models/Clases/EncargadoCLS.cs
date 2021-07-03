using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EncargadoCLS
    {
        public int id_Encargado { get; set; }
        public string tipo_Encargado { get; set; }
        public string pass { get; set; }
        public int id_Usuario { get; set; }
        public string nombre { get; set; }
    }
}