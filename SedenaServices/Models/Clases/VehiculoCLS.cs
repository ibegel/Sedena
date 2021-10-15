using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedenaServices.Models.Clases
{
    public class VehiculoCLS
    {
        public int idVehiculo { get; set; }
        public string placa { get; set; }
        public string color { get; set; }
        public string marca { get; set; }
        public string nombre { get; set; }

        public VehiculoCLS(int idVehiculo , string placa,string color, string marca, string nombre)
        {
            this.idVehiculo = idVehiculo;
            this.placa = placa;
            this.color = color;
            this.marca = marca;
            this.nombre = nombre;
        }
        public VehiculoCLS()
        {
           
        }
    }
}