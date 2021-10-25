using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Funcion 
    public class FuncionCLS
    {
        public int idFuncion { get; set; }
        public string funcion { get; set; }
        public int idAgente { get; set; }
        public int idSesion { get; set; }
        //constructor vacio de la clase  Funcion
        public FuncionCLS()
        {
           
        }
    }
}