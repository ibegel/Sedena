using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    //Objeto auxiliar que nos ayudara a manipular de una manera mas sencilla la tabla Update 
    public class UpdateCLS
    {
        public String ultimaActualizacion { get; set; }
        public int numeroAgentes { get; set; }
        public int numeroEncargados { get; set; }

        //Contructor vacio de la clase
        public UpdateCLS()
        {
            
        }
        //Constructor de la clase en el cual recibe un objeto del mismo tipo
        public UpdateCLS(UpdateCLS up)
        {
            this.ultimaActualizacion = up.ultimaActualizacion;
            this.numeroAgentes = up.numeroAgentes;
            this.numeroEncargados = up.numeroEncargados;
        }
    }
}