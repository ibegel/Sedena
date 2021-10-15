using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EvaluacionCLS
    {
        public string funcion { get; set; }
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string actividad { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public float tiempo { get; set; }
        public int disparosRealizados { get; set; }
        public int disparosAcertados { get; set; }
        public int disparosColateral { get; set; }
        public int bajasMilitares { get; set; }
        public int bajasColaterales { get; set; }
        public int bajasEnemigos { get; set; }
        public bool usoCorrecto { get; set; }
        public bool misionCumplida { get; set; }
        //public EvaluacionCLS(string nombre, string matricula, int disparos_Realizados, int disparos_Acertados, int disparos_Colateral, int bajas_Militares, int bajas_Colaterales, int bajas_Enemigos, bool uso_Correcto, ool mision_Cumplida)
        public EvaluacionCLS()
        {



        }

        public EvaluacionCLS(EvaluacionCLS Otro)
        {
            funcion = Otro.funcion;
            nombre = Otro.nombre;
            matricula = Otro.matricula;
            disparosAcertados = Otro.disparosAcertados;
            disparosColateral = Otro.disparosColateral;
            disparosRealizados = Otro.disparosRealizados;
            bajasMilitares = Otro.bajasMilitares;
            bajasEnemigos = Otro.bajasEnemigos;
            bajasColaterales = Otro.bajasColaterales;
            usoCorrecto = Otro.usoCorrecto;
            misionCumplida = Otro.misionCumplida;
        }
    }
    [Serializable]
    public class EvaluacionesCLS
    {
        public EvaluacionCLS[] lista;
    }
}