using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class Catalogo_ITCLS
    {
        public int id_Incidente;
        public string nombre;
        public Catalogo_ITCLS(int id_Incidente, string nombre)
        {
            this.id_Incidente = id_Incidente;
            this.nombre = nombre;        
        }
        public Catalogo_ITCLS()
        {
        }
    }
}