using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServiciosMedicamentos.Scripts
{
    [DataContract]
    public class MedicamentoCLS
    {
        [DataMember(Order =0)]
        public int idmedicamento { get; set; }
        [DataMember(Order = 1)]
        public string nombre { get; set; }
        [DataMember(Order = 2)]
        public string concentracion { get; set; }
        [DataMember(Order = 3)]
        public int idformafarmaceutica { get; set; }
        [DataMember(Order = 4)]
        public int nombreformafarmaceutica { get; set; }
        [DataMember(Order = 5)]
        public decimal precio { get; set; }
        [DataMember(Order = 6)]
        public decimal stock { get; set; }
        [DataMember(Order = 7)]
        public string  presentacion { get; set; }
        [DataMember(Order = 8)]
        public int bhabilitado { get; set; }
    }
}
