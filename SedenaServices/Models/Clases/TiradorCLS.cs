using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Tirador
    public class TiradorCLS
    {
        public int idFuncion { get; set; }
        public bool usoCorrecto { get; set; }
        public bool misionCumplida { get; set; }
        public int disparosRealizados  { get; set; }
        public int disparosAcertados { get; set; }
        public int disparosColateral { get; set; }
        public int bajasMilitares { get; set; }
        public int bajasColaterales { get; set; }
        public int bajasEnemigos { get; set; }
        //constructor vacio de la clase 
        public TiradorCLS()
        { 
        }
    }
    //lista de los objetos TiradorCLS que sirve para convertir a formato JSON
    [Serializable]
    public class TiradoresCLS
    {
        public TiradorCLS[] tiradores;
    }
}