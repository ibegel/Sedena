using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class ConductorCLS
    {
        public int idFuncion { get; set; }
        public int colisiones { get; set; }
        public float tiempo { get; set; }
        public bool misionCumplida {get; set;}
        public bool usoCorrecto { get; set; }

        public ConductorCLS()
        {
            
        }
    }
    [Serializable]
    public class ConductoresCLS
    {
        public ConductorCLS[] conductores;
    }

}