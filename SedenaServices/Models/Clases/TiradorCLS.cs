﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class TiradorCLS
    {
        public int idFuncion { get; set; }
        public int idArma { get; set; }
        public bool usoCorrecto { get; set; }
        public bool misionCumplida { get; set; }
        public int disparosRealizados  { get; set; }
        public int disparosAcertados { get; set; }
        public int disparosColateral { get; set; }
        public int bajasMilitares { get; set; }
        public int bajasColaterales { get; set; }
        public int bajasEnemigos { get; set; }





        public TiradorCLS(int idFuncion, int idArma,bool usoCorrecto,bool misionCumplida)
        {
            this.idFuncion = idFuncion;
            this.idArma = idArma;
            this.usoCorrecto = usoCorrecto;
            this.misionCumplida = misionCumplida;
        }

        public TiradorCLS()
        { 
        }
    }
}