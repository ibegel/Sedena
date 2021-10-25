using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Conductor
    public class ConductorCLS
    {
        public int idFuncion { get; set; }
        public int colisiones { get; set; }
        public float tiempo { get; set; }
        public bool misionCumplida {get; set;}
        public bool usoCorrecto { get; set; }
        //constructor vacio de la clase  conductor
        public ConductorCLS()
        {
            
        }
    }
    //lista de los objetos ConducorCLS que sirve para convertir a formato JSON
    [Serializable]
    public class ConductoresCLS
    {
        public ConductorCLS[] conductores;
    }

}