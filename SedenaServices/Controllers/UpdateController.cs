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
    //Devuelve campos que seran utiles para saber como esta creciendo las tablas en la base de datos
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    public class UpdateController : ApiController
    {
        //Recupera los datos de la tabla Actualizacion los cuales son:
        //      ultimaActualizacion: guarda la fecha de ultima actualizacion de cualquier tabla 
        //      numeroAgentes:  cuenta el numero de agentes existentes en la tabla Agentes
        //      numeroEncargados: cuenta el numero de encargados existente en la tabla Encargados
        //los convierte en una lista y devuelve el ultimo campo insertado puesto que ese campo tiene los datos mas recientes  
        //
        [HttpGet]
        
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
