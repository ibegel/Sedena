using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class Incidentes_TiradorCLS
    {
        public int id_Funcion;
        public int id_Incidente;
        public int numero_Incidente;
        public Incidentes_TiradorCLS(int id_Funcion, int id_Incidente,int numero_Incidente)
        {
            this.id_Funcion = id_Funcion;
            this.id_Incidente = id_Incidente;
            this.numero_Incidente = numero_Incidente;
        }
        public Incidentes_TiradorCLS()
        {
        }
    }
}