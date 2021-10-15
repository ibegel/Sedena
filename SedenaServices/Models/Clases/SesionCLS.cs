using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class SesionCLS
    {
        public int idSesion { get; set; }
        public string actividad { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public int idEncargado { get; set; }

        public SesionCLS()
        {
            
        }

        public SesionCLS(int idSesion, string actividad, string entorno, string fecha,int idEncargado)
        {
            this.idSesion = idSesion;
            this.actividad = actividad;
            this.entorno = entorno;
            this.fecha = fecha;
            this.idEncargado = idEncargado;
        }
    }
}