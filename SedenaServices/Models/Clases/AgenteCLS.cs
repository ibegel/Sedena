using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class AgenteCLS
    {
        public int id_Agente { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string nombre { get; set; }
        public string distintivo { get; set; }

        public AgenteCLS(int id_Agente, string matricula, string grado, string nombre, string distintivo)
        {
            this.id_Agente = id_Agente;
            this.matricula = matricula;
            this.grado = grado;
            this.nombre = nombre;
            this.distintivo = distintivo;
        }
        public AgenteCLS()
        {
        }


    }

    [Serializable]
    public class AgentesCLS
        {
            public AgenteCLS[] agentes;
        }
  

}
