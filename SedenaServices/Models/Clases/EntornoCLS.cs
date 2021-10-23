using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class EntornoCLS
    {
        public string name { get; set; }
        public string escenario { get; set; }
        public string descripcion { get; set; }
        public string jsonOdin { get; set; }
        public EntornoCLS()
        {
            
        }

    }
    public class EntornosCLS
    {
        public EntornoCLS[] entornos;
    }
}