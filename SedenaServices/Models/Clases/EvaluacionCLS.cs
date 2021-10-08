using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EvaluacionCLS
    {
        public string nombre { get; set; }
        public string matricula { get; set; }
        public int disparos_Realizados { get; set; }
        public int disparos_Acertados { get; set; }
        public int disparos_Colateral { get; set; }
        public int bajas_Militares { get; set; }
        public int bajas_Colaterales { get; set; }
        public int bajas_Enemigos { get; set; }
        public bool uso_Correcto { get; set; }
        public bool mision_Cumplida { get; set; }
        //public EvaluacionCLS(string nombre, string matricula, int disparos_Realizados, int disparos_Acertados, int disparos_Colateral, int bajas_Militares, int bajas_Colaterales, int bajas_Enemigos, bool uso_Correcto, ool mision_Cumplida)
        public EvaluacionCLS()
        {



        }
    }
    [Serializable]
    public class EvaluacionesCLS
    {
        public EvaluacionCLS[] lista;
    }
}