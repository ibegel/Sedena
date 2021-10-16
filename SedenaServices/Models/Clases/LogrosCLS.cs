using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class LogrosCLS
    {
        public TiradorCLS[] listaTiradores { get; set; }
        //public ConductorCLS[] listaConductores { get; set; }
        public List<string> aTirador = new List<string> {"disparosAcertado","disparosColateral","bajasMilitares","bajasColaterales","bajasEnemigos"};
        public List<string> aConductor = new List<string> { "Aqui pondria mis evaluaciones Si tuviera alguna" };
        public LogrosCLS()
        {
            
        }
    }
}