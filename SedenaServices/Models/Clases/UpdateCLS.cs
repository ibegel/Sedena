using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class UpdateCLS
    {
        public String ultimaActualizacion { get; set; }
        public int numeroAgentes { get; set; }
        public int numeroEncargados { get; set; }


        public UpdateCLS()
        {
            
        }

        public UpdateCLS(UpdateCLS up)
        {
            this.ultimaActualizacion = up.ultimaActualizacion;
            this.numeroAgentes = up.numeroAgentes;
            this.numeroEncargados = up.numeroEncargados;
        }
    }
}