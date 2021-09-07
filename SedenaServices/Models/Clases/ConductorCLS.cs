﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ConductorCLS
    {
        public int id_Funcion { get; set; }
        public int id_Vehiculo { get; set; }

        public ConductorCLS()
        {
            
        }
        public ConductorCLS(int id_Funcion,int id_Vehiculo)
        {
            this.id_Funcion = id_Funcion;
            this.id_Vehiculo = id_Vehiculo;
        }
    }
}