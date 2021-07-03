using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class UsuarioCLS
    {
        public int id_Usuario { get; set; }
        public string clave { get; set; }
        public string rango { get; set; }
        public string nombre { get; set; }

        public UsuarioCLS(int id_Usuario, string clave, string rango, string nombre)
        {
            this.id_Usuario = id_Usuario;
            this.clave = clave;
            this.rango = rango;
            this.nombre = nombre;
        }
        public UsuarioCLS()
        { 
        }
    }
}