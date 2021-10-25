using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Agente
    public class AgenteCLS
    {
        public int idAgente { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string nombre { get; set; }
        public string distintivo { get; set; }
        public string arma { get; set; }
        public int existencia { get; set; }

        //constructor vacio de la clase 
        public AgenteCLS()
        {
        }


    }
    //lista de los objetos AgenteCLS que sirve para convertir a formato JSON
    [Serializable]
    public class AgentesCLS
        {
            public AgenteCLS[] agentes;
        }
  

}
