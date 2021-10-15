﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class AgenteCLS
    {
        public int idAgente { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string nombre { get; set; }
        public string distintivo { get; set; }
        public string arma { get; set; }
        public int existencia { get; set; }

        public AgenteCLS(int idAgente, string matricula, string grado, string nombre, string distintivo, string especialidad)
        {
            this.idAgente = idAgente;
            this.matricula = matricula;
            this.grado = grado;
            this.nombre = nombre;
            this.distintivo = distintivo;
            this.arma = especialidad;
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
