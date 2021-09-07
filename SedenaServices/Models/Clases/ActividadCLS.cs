using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ActividadCLS
    {
        public int id_Actividad;
        public string nombre;
        public string dificultad;
        public string tipo;

        public ActividadCLS(int id_Actividad,string nombre, string dificultad ,string tipo)
        {
            this.id_Actividad = id_Actividad;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.tipo = tipo;
        }
    }
}