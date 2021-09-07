using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class SesionCLS
    {
        public int id_Sesion { get; set; }
        public int id_Actividad { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public int id_Encargado { get; set; }

        public SesionCLS()
        {
            
        }

        public SesionCLS(int id_Sesion, int id_Actividad, string entorno, string fecha,int encargado)
        {
            this.id_Sesion = id_Sesion;
            this.id_Actividad = id_Actividad;
            this.entorno = entorno;
            this.fecha = fecha;
            this.id_Encargado = id_Encargado;
        }
    }
}