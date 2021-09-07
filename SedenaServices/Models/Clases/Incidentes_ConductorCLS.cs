using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class Incidentes_ConductorCLS
    {

            public int id_Incidente;
            public int id_Funcion;
            public int numero_Incidente;

            public Incidentes_ConductorCLS(int id_Incidente, int id_Funcion, int numero_Incidente)
            {
                this.id_Incidente = id_Incidente;
                this.id_Funcion = id_Funcion;
                this.numero_Incidente = numero_Incidente;
            }
            public Incidentes_ConductorCLS()
            {

            }
        }
    }
