using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Entorno
    public class EntornoCLS
    {
        public string name { get; set; }
        public string escenario { get; set; }
        public string descripcion { get; set; }
        public string jsonOdin { get; set; }
        //constructor vacio de la clase  Entorno
        public EntornoCLS()
        {

        }

    }
    //lista de los objetos EntornosCLS que sirve para convertir a formato JSON
    public class EntornosCLS
    {
        public EntornoCLS[] entornos;
    }
}