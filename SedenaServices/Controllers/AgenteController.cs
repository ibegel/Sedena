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
    public class AgenteController : ApiController
    {
        [HttpGet]
        public AgentesCLS listaAgente()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                AgentesCLS agentes = new AgentesCLS();
                List<AgenteCLS> listaAgente = (from usuario in bd.Agente
                                                       
                                                        select new AgenteCLS
                                                        {
                                                            idAgente = usuario.Id_Agente,
                                                            matricula = usuario.Matricula,
                                                            grado = usuario.Grado,
                                                            nombre = usuario.Nombre,
                                                            distintivo= usuario.Distintivo,
                                                            arma=usuario.Arma,
                                                            existencia=(int)usuario.Existencia
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
        public string agregarAgente(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            string respuesta = "";
            List<AgenteCLS> matri = new List<AgenteCLS>() { };
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                 matri = (from usuario in bd.Agente

                                               select new AgenteCLS
                                               {
                                                   idAgente= usuario.Id_Agente,
                                                   matricula = usuario.Matricula
                                               }).ToList();
  
            }
            int bandera = 0;
            foreach (var x in matri)
            { 
                if(x.matricula.Equals((string)json["matricula"]))
                      {
                    if (x.idAgente.Equals((int)json["idAgente"]))
                    {
                        bandera = 0;
                    }
                    else 
                    {
                        bandera=1;
                        break;
                    }
                    
            }   
            }

            if (bandera==0) { 
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if ((int)json["idAgente"] == 0)
                    {
                        IEnumerable<AgenteCLS> listaUsuario = (from usuario in bd.Agente
                                                               select new AgenteCLS
                                                                {
                                                                    idAgente = usuario.Id_Agente,
                                                                    matricula = usuario.Matricula,
                                                                    grado = usuario.Grado,
                                                                    nombre = usuario.Nombre,
                                                                    distintivo = usuario.Distintivo,
                                                                    arma=usuario.Arma
                                                                }).ToList();
                        Agente nuevoAgente = new Agente();
                        nuevoAgente.Id_Agente = listaUsuario.Last().idAgente + 1;
                        
                        nuevoAgente.Matricula = (string)json["matricula"];
                        nuevoAgente.Grado = (string)json["grado"];
                        nuevoAgente.Nombre = (string)json["nombre"];
                        nuevoAgente.Distintivo = (string)json["distintivo"];
                        nuevoAgente.Arma = (string)json["arma"];
                        nuevoAgente.Existencia = 1;
                        bd.Agente.InsertOnSubmit(nuevoAgente);
                        bd.SubmitChanges();
                        respuesta = "Insertado";
                    }
                    else
                    {
                        Agente aux = bd.Agente.Where(p => p.Id_Agente == (int)json["idAgente"]).First();
                        aux.Id_Agente = (int)json["idAgente"];
                        aux.Matricula = (string)json["matricula"];
                        aux.Grado = (string)json["grado"];
                        aux.Nombre = (string)json["nombre"];
                        aux.Distintivo = (string)json["distintivo"];
                        aux.Arma = (string)json["arma"];
                        aux.Existencia = 1;
                        bd.SubmitChanges();
                        respuesta = "Actualizado";
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
            }
            else
            {
                return respuesta = "Matricula ya existente";
            }

            // return "Estos me enviaste"+oUsuario.id_Agente+" , " + oUsuario.matricula + " , " + oUsuario.grado + " , " + oUsuario.nombre + " , " + oUsuario.distintivo + " , " + oUsuario.arma + " , " + oUsuario.existencia;
        }

        [HttpGet]
        public AgenteCLS recuperarAgente(int id_Agente)
        {
            
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    List<AgenteCLS> listarAgente = (from usu in bd.Agente
                                                          select new AgenteCLS
                                                          {
                                                              idAgente = usu.Id_Agente,
                                                              matricula = usu.Matricula,
                                                              grado = usu.Grado,
                                                              nombre = usu.Nombre,
                                                              distintivo = usu.Distintivo,
                                                              arma = usu.Arma,
                                                              existencia = (int)usu.Existencia


                                                          }).ToList();
                    AgenteCLS aux = new AgenteCLS();
                    foreach (var a in listarAgente)
                    {
                        if (a.idAgente.Equals(id_Agente))
                        {
                            aux = a;
                            break;
                        }
                    }
                    return aux;
                }
            
        }

        [HttpGet]
        public AgenteCLS recuperarNombre(string nombre)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<AgenteCLS> listarAgente = (from usu in bd.Agente
                                                select new AgenteCLS
                                                {
                                                    idAgente = usu.Id_Agente,
                                                    matricula = usu.Matricula,
                                                    grado = usu.Grado,
                                                    nombre = usu.Nombre,
                                                    distintivo = usu.Distintivo,
                                                    arma = usu.Arma,
                                                    existencia = (int)usu.Existencia


                                                }).ToList();
                AgenteCLS aux = new AgenteCLS();
                foreach (var a in listarAgente)
                {
                    if (a.nombre.ToLower().Equals(nombre.ToLower()))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

        [HttpGet]
        public AgenteCLS recuperarDistintivo(string distintivo)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<AgenteCLS> listarAgente = (from usu in bd.Agente
                                                select new AgenteCLS
                                                {
                                                    idAgente = usu.Id_Agente,
                                                    matricula = usu.Matricula,
                                                    grado = usu.Grado,
                                                    nombre = usu.Nombre,
                                                    distintivo = usu.Distintivo,
                                                    arma = usu.Arma,
                                                    existencia = (int)usu.Existencia


                                                }).ToList();
                AgenteCLS aux = new AgenteCLS();
                foreach (var a in listarAgente)
                {
                    if (a.distintivo.ToLower().Equals(distintivo.ToLower()))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

        [HttpGet]
        public AgenteCLS recuperarMatricula(string matricula)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<AgenteCLS> listarAgente = (from usu in bd.Agente
                                                select new AgenteCLS
                                                {
                                                    idAgente = usu.Id_Agente,
                                                    matricula = usu.Matricula,
                                                    grado = usu.Grado,
                                                    nombre = usu.Nombre,
                                                    distintivo = usu.Distintivo,
                                                    arma = usu.Arma,
                                                    existencia = (int)usu.Existencia


                                                }).ToList();
                AgenteCLS aux = new AgenteCLS();
                foreach (var a in listarAgente)
                {
                    if (a.matricula.Equals(matricula))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

    }
}
