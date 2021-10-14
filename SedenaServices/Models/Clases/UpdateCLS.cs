using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class UpdateCLS
    {
        public String ultima_Actualizacion { get; set; }
        public int numero_Agentes { get; set; }
        public int numero_Encargados { get; set; }


        public UpdateCLS()
        {
            
        }

        public UpdateCLS(UpdateCLS up)
        {
            this.ultima_Actualizacion = up.ultima_Actualizacion;
            this.numero_Agentes = up.numero_Agentes;
            this.numero_Encargados = up.numero_Encargados;
        }
    }
}