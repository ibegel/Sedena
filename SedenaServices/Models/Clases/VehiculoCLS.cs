using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class VehiculoCLS
    {
        public int id_Vehiculo { get; set; }
        public string placa { get; set; }
        public string color { get; set; }
        public string marca { get; set; }
        public string nombre { get; set; }

        public VehiculoCLS(int id_Vehiculo , string placa,string color, string marca, string nombre)
        {
            this.id_Vehiculo = id_Vehiculo;
            this.placa = placa;
            this.color = color;
            this.marca = marca;
            this.nombre = nombre;
        }
    }
}