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
    public class AgenteController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<AgenteCLS> listaUsuario()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<AgenteCLS> listaAgente = (from usuario in bd.Agente
                                                        where usuario.Matricula != null
                                                        select new AgenteCLS
                                                        {
                                                            id_Agente = usuario.Id_Agente,
                                                            matricula = usuario.Matricula,
                                                            grado = usuario.Grado,
                                                            nombre = usuario.Nombre,
                                                            distintivo= usuario.Distintivo

                                                        }).ToList();
                return listaAgente;
            }
        }

        [HttpPut]
        public int eliminarUsuario(int id_Agente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Agente oUsuario = bd.Agente.Where(p => p.Id_Agente == id_Agente).First();
                    oUsuario.Matricula = null;
                    bd.SubmitChanges();
                    respuesta = 1;
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            return respuesta;
        }


        [HttpPost]
        public int agregarUsuario(Agente oUsuario)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oUsuario.Id_Agente == 0)
                    {
                        IEnumerable<AgenteCLS> listaUsuario = (from usuario in bd.Agente
                                                                where usuario.Matricula != null
                                                                select new AgenteCLS
                                                                {
                                                                    id_Agente = usuario.Id_Agente,
                                                                    matricula = usuario.Matricula,
                                                                    grado = usuario.Grado,
                                                                    nombre = usuario.Nombre,
                                                                    distintivo = usuario.Distintivo
                                                                }).ToList();

                        oUsuario.Id_Agente = listaUsuario.Count() + 1;
                        bd.Agente.InsertOnSubmit(oUsuario);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Agente aux = bd.Agente.Where(p => p.Id_Agente == oUsuario.Id_Agente).First();
                        aux.Id_Agente = oUsuario.Id_Agente;
                        aux.Matricula = oUsuario.Matricula;
                        aux.Grado = oUsuario.Grado;
                        aux.Nombre = oUsuario.Nombre;
                        aux.Distintivo = oUsuario.Distintivo;
                        bd.SubmitChanges();
                        respuesta = 1;

                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = 0;
            }
            return respuesta;
        }

        [HttpGet]
        public AgenteCLS recuperarUsuario(int id_Agente)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgenteCLS oUsuario = bd.Agente.Where(p => p.Id_Agente == id_Agente)
                    .Select(p => new AgenteCLS
                    {
                        id_Agente = p.Id_Agente,
                        matricula = p.Matricula,
                        grado = p.Grado,
                        nombre = p.Nombre,
                        distintivo=p.Distintivo
                    }
                    ).First();

                return oUsuario;


            }
        }

    }
}
