using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class FuncionCLS
    {
        public int id_Funcion { get; set; }
        public string funcion { get; set; }
        public int id_Usuario { get; set; }
        public int id_Sesion { get; set; }
    }
}