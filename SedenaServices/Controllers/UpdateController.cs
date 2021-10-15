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
                                                                ultimaActualizacion=upd.Ultima_Actualizacion,
                                                                numeroAgentes=(int)upd.Numero_Agentes,
                                                                numeroEncargados=(int)upd.Numero_Encargados

                                                         }).ToList();
                UpdateCLS final = new UpdateCLS(lista.Last());
                return "La ultima actualizacion: " + final.ultimaActualizacion + "Numero de Agentes: " + final.numeroAgentes + "Numero de Encargados: " + final.numeroEncargados;
            }
        }
    }
}
