﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EncargadoCLS
    {
        public int idEncargado { get; set; }
        public string tipoEncargado { get; set; }
        public string pass { get; set; }
        public int idAgente { get; set; }
        public string nombre { get; set; }
        public string matricula { get; set; }
        public string grado { get; set; }
        public string distintivo { get; set; }
        public string arma { get; set; }
        public int existencia { get; set; }

        public EncargadoCLS(int idEncargado, string tipoEncargado, string pass, int idAgente)
        {
            this.idEncargado = idEncargado;
            this.tipoEncargado = tipoEncargado;
            this.pass = pass;
            this.idAgente = idAgente;
        }

        public EncargadoCLS()
        {

        }
    }

    public class EncargadosCLS
        {
        public EncargadoCLS[] encargados;

        }

    
}