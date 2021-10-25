using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Encargado
    public class EncargadoCLS
    {
        public int idEncargado { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int idAgente { get; set; }
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string distintivo { get; set; }
        public string arma { get; set; }
        public int existencia { get; set; }

        //constructor vacio de la clase encargado
        public EncargadoCLS()
        {

        }
    }
    //lista de los objetos EncargadoCLS que sirve para convertir a formato JSON
    [Serializable]
    public class EncargadosCLS
        {
        public EncargadoCLS[] encargados;

        }

    
}