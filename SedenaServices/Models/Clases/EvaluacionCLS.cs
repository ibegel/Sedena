using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular el flujo de datos en el controlador Evaluacion 
    public class EvaluacionCLS
    {
        public string funcion { get; set; }
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string actividad { get; set; }
        public string entorno { get; set; }
        public string fecha { get; set; }
        public float tiempo { get; set; }
        public int colisiones { get; set; }

        public string matriculaEncargado { get; set; }
        public int idEncargado { get; set; }
        public int disparosRealizados { get; set; }
        public int disparosAcertados { get; set; }
        public int disparosColateral { get; set; }
        public int bajasMilitares { get; set; }
        public int bajasColaterales { get; set; }
        public int bajasEnemigos { get; set; }
        public bool usoCorrecto { get; set; }
        public bool misionCumplida { get; set; }
        //Creacion del constructor vacio de la clase
        public EvaluacionCLS()
        {

        }
        //Creacion del constructor de la clase obteniendo un objeto del mismo tipo
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

    //Lista de evaluaciones que nos ayudaran a regresar los objetos en tipo Json 
    [Serializable]
    public class EvaluacionesCLS
    {
        public List<EvaluacionCLS> lista=new List<EvaluacionCLS>() { };
    }
}