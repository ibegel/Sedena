using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class FuncionCLS
    {
        public int id_Funcion { get; set; }
        public string funcion { get; set; }
        public int id_Agente { get; set; }
        public int id_Sesion { get; set; }

        public FuncionCLS(int id_Funcion, string funcion,int id_Agente, int id_Sesion)
        {
            this.id_Funcion = id_Funcion;
            this.funcion = funcion;
            this.id_Agente = id_Agente;
            this.id_Sesion = id_Sesion;
        }
        public FuncionCLS()
        {
           
        }
    }
}