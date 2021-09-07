using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EncargadoCLS
    {
        public int id_Encargado { get; set; }
        public string tipo_Encargado { get; set; }
        public string pass { get; set; }
        public int id_Agente { get; set; }

        public EncargadoCLS(int id_Encargado, string tipo_Encargado,string pass,int id_Agente)
        {
            this.id_Encargado = id_Encargado;
            this.tipo_Encargado = tipo_Encargado;
            this.pass = pass;
            this.id_Agente = id_Agente;
        }

        public EncargadoCLS()
        {

        }
    }

    
}