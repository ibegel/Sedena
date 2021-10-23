using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SedenaServices.Models.Clases;
using SedenaServices.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace SedenaServices.Controllers
{
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    public class EntornoController : ApiController
    {
        [HttpGet]
        public EntornosCLS listaEntorno()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                List<EntornoCLS> listaEnt = (from ento in bd.Entorno
                                             select new EntornoCLS
                                             {
                                                 name = ento.Nombre,
                                                 escenario = ento.Escenario,
                                                 descripcion = ento.Descripcion,
                                                 jsonOdin = ento.JsonOdin
                                             }).ToList();
                ent.entornos = listaEnt.ToArray();
                return ent;

            }
        }

        [HttpPost]
        public string agregarAgente(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            string respuesta = "";
            int existe = 0;
            EntornosCLS lista_nombre = new EntornosCLS();
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                lista_nombre.entornos = (from ento in bd.Entorno
                                             select new EntornoCLS
                                             {
                                                 name = ento.Nombre,
                                             }).ToArray();
            }

            foreach (var x in lista_nombre.entornos)
            {
                if (x.name == (string)json["name"])
                {
                    existe = 1;
                    break;
                }
            }
            if (existe == 0)
            {
                try
                {
                    using (DBSedenaDataContext bd = new DBSedenaDataContext())
                    {
                        Entorno nuevo = new Entorno() { };

                        nuevo.Nombre = (string)json["name"];
                        nuevo.Escenario = (string)json["escenario"];
                        nuevo.Descripcion = (string)json["descripcion"];
                        nuevo.JsonOdin = (string)json["jsonOdin"];
                        bd.Entorno.InsertOnSubmit(nuevo);
                        bd.SubmitChanges();
                    }
                    respuesta = "Ingresado";                
                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;
                }
            }
            else 
            {
                respuesta = "El nombre ya esta ocupado";
            }
                return respuesta;
            }


        [HttpGet]
        public EntornoCLS listaEntorno(string name)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                EntornoCLS seleccion = (from ento in bd.Entorno
                                        where ento.Nombre == name
                                        select new EntornoCLS
                                        {
                                            name = ento.Nombre,
                                            escenario = ento.Escenario,
                                            descripcion = ento.Descripcion,
                                            jsonOdin = ento.JsonOdin
                                        }).First();
                return seleccion;

            }
        }


    }
    

}
