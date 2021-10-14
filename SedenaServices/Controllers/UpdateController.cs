using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SedenaServices.Models.Clases;
using SedenaServices.Models;
using System.Web.Http.Cors;


namespace SedenaServices.Controllers
{
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    public class UpdateController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public string listaUpdate()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                
                IEnumerable<UpdateCLS> lista = (from upd in bd.Actualizacion
                                                         select new UpdateCLS
                                                         {
                                                                ultima_Actualizacion=upd.Ultima_Actualizacion,
                                                                numero_Agentes=(int)upd.Numero_Agentes,
                                                                numero_Encargados=(int)upd.Numero_Encargados

                                                         }).ToList();
                UpdateCLS final = new UpdateCLS(lista.Last());
                return "La ultima actualizacion: " + final.ultima_Actualizacion + "\nNumero de Agentes: " + final.numero_Agentes + "\nNumero de Encargados: " + final.numero_Encargados;
            }
        }
    }
}
