using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Sesion
    public class SesionCLS
    {
        public int idSesion { get; set; }
        public string actividad { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public int idEncargado { get; set; }
        //constructor vacio de la clase Sesion
        public SesionCLS()
        {
            
        }

       
    }
}