using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class AgenteCLS
    {
        public int id_Entidad { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string nombre { get; set; }
        public string distintivo { get; set; }

        public AgenteCLS(int id_Entidad, string matricula, string grado, string nombre, string distintivo)
        {
            this.id_Entidad = id_Entidad;
            this.matricula = matricula;
            this.grado= grado;
            this.nombre = nombre;
            this.distintivo = distintivo;
        }
        public AgenteCLS()
        {
        }
    }
}