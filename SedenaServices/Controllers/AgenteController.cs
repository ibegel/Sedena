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
        public AgentesCLS listaAgente()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgentesCLS agentes = new AgentesCLS();
                List<AgenteCLS> listaAgente = (from usuario in bd.Agente
                                                        where usuario.Nombre != "Inhabilitado"
                                                        select new AgenteCLS
                                                        {
                                                            id_Agente = usuario.Id_Agente,
                                                            matricula = usuario.Matricula,
                                                            grado = usuario.Grado,
                                                            nombre = usuario.Nombre,
                                                            distintivo= usuario.Distintivo
                                                        }).ToList();
                agentes.agentes = listaAgente.ToArray();
                return agentes;

            }
        }

        [HttpDelete]
        public int eliminarAgente(int id_Agente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Agente oUsuario = bd.Agente.Where(p => p.Id_Agente == id_Agente).First();
                    bd.Agente.DeleteOnSubmit(oUsuario);
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

        [HttpPut]
        public int deshabilitarAgente(int id_Agente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Agente oAgente = bd.Agente.Where(p => p.Id_Agente == id_Agente).First();
                    oAgente.Nombre = "Inhabilitado";
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
        public int agregarAgente(Agente oUsuario)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oUsuario.Id_Agente == 0)
                    {
                        IEnumerable<AgenteCLS> listaUsuario = (from usuario in bd.Agente
                                                               where usuario.Nombre != "Inhabilitado"
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
        public AgenteCLS recuperarAgente(int id_Agente)
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

        [HttpGet]
        public AgenteCLS recuperarNombre(string nombre)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgenteCLS oUsuario = bd.Agente.Where(p => p.Nombre == nombre)
                    .Select(p => new AgenteCLS
                    {
                        id_Agente = p.Id_Agente,
                        matricula = p.Matricula,
                        grado = p.Grado,
                        nombre = p.Nombre,
                        distintivo = p.Distintivo
                    }
                    ).First();
                return oUsuario;
            }
        }

        [HttpGet]
        public AgenteCLS recuperarDistintivo(string distintivo)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgenteCLS oUsuario = bd.Agente.Where(p => p.Distintivo == distintivo)
                    .Select(p => new AgenteCLS
                    {
                        id_Agente = p.Id_Agente,
                        matricula = p.Matricula,
                        grado = p.Grado,
                        nombre = p.Nombre,
                        distintivo = p.Distintivo
                    }
                    ).First();
                return oUsuario;
            }
        }

        [HttpGet]
        public AgenteCLS recuperarMatricula(string matricula)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgenteCLS oUsuario = bd.Agente.Where(p => p.Matricula == matricula)
                    .Select(p => new AgenteCLS
                    {
                        id_Agente = p.Id_Agente,
                        matricula = p.Matricula,
                        grado = p.Grado,
                        nombre = p.Nombre,
                        distintivo = p.Distintivo
                    }
                    ).First();
                return oUsuario;
            }
        }

    }
}
