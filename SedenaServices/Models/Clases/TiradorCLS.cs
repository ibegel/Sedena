using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class TiradorCLS
    {
        public int id_Funcion { get; set; }
        public int id_Arma { get; set; }
        public bool uso_Correcto { get; set; }
        public bool mision_Cumplida { get; set; }
        public int disparos_Realizados  { get; set; }
        public int disparos_Acertados { get; set; }
        public int disparos_Colateral { get; set; }
        public int bajas_Militares { get; set; }
        public int bajas_Colaterales { get; set; }
        public int bajas_Enemigos { get; set; }





        public TiradorCLS(int id_Funcion, int id_Arma,bool uso_Correcto,bool mision_Cumplida)
        {
            this.id_Funcion = id_Funcion;
            this.id_Arma = id_Arma;
            this.uso_Correcto = uso_Correcto;
            this.mision_Cumplida = mision_Cumplida;
        }

        public TiradorCLS()
        { 
        }
    }
}