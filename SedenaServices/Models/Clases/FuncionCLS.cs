using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class FuncionCLS
    {
        public int idFuncion { get; set; }
        public string funcion { get; set; }
        public int idAgente { get; set; }
        public int idSesion { get; set; }

        public FuncionCLS(int idFuncion, string funcion,int idAgente, int idSesion)
        {
            this.idFuncion = idFuncion;
            this.funcion = funcion;
            this.idAgente = idAgente;
            this.idSesion = idSesion;
        }
        public FuncionCLS()
        {
           
        }
    }
}