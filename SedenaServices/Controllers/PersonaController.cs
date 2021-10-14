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
    public class PersonaController : ApiController
    {

        [HttpPost]
        public string agregarPersona(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            string respuesta=" ";
            foreach (var e in json)
            {
                respuesta += e.Key;
            }
            return respuesta;
            
            /*try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    //Agente
                    if (oPersona.tipo_Encargado == null && oPersona.pass == null)
                    {
                        //Insertar
                        if (oPersona.id_Agente == 0)
                        {
                            IEnumerable<AgenteCLS> listaUsuario = (from usuario in bd.Agente
                                                                   select new AgenteCLS
                                                                   {
                                                                       id_Agente = usuario.Id_Agente,
                                                                       matricula = usuario.Matricula,
                                                                       grado = usuario.Grado,
                                                                       nombre = usuario.Nombre,
                                                                       distintivo = usuario.Distintivo,
                                                                       arma = usuario.Arma
                                                                   }).ToList();

                            oPersona.id_Agente = listaUsuario.Last().id_Agente + 1;
                            Agente nuevoAgente = new Agente();
                            nuevoAgente.Id_Agente = oPersona.id_Agente;
                            nuevoAgente.Matricula = oPersona.matricula;
                            nuevoAgente.Grado = oPersona.grado;
                            nuevoAgente.Nombre = oPersona.nombre;
                            nuevoAgente.Distintivo = oPersona.distintivo;
                            nuevoAgente.Arma = oPersona.arma;
                            nuevoAgente.Existencia = oPersona.existencia;
                            bd.Agente.InsertOnSubmit(nuevoAgente);
                            bd.SubmitChanges();
                            respuesta = "Agente Insertado";
                        }
                        //Actualizar
                        else
                        {
                            Agente aux = bd.Agente.Where(p => p.Id_Agente == oPersona.id_Agente).First();
                            aux.Id_Agente = oPersona.id_Agente;
                            aux.Matricula = oPersona.matricula;
                            aux.Grado = oPersona.grado;
                            aux.Nombre = oPersona.nombre;
                            aux.Distintivo = oPersona.distintivo;
                            aux.Arma = oPersona.arma;
                            bd.SubmitChanges();
                            respuesta = "Agente Actualizado";
                        }
                    }
                    //Insertar un nuevo Encargado
                    else 
                    {
                        //insertar
                        if (oPersona.id_Agente == 0)
                        {
                            IEnumerable<AgenteCLS> listaUsuario = (from usuario in bd.Agente
                                                                   select new AgenteCLS
                                                                   {
                                                                       id_Agente = usuario.Id_Agente,
                                                                       matricula = usuario.Matricula,
                                                                       grado = usuario.Grado,
                                                                       nombre = usuario.Nombre,
                                                                       distintivo = usuario.Distintivo,
                                                                       arma = usuario.Arma
                                                                   }).ToList();

                            oPersona.id_Agente = listaUsuario.Last().id_Agente + 1;
                            Agente nuevoAgente = new Agente();
                            nuevoAgente.Id_Agente = oPersona.id_Agente;
                            nuevoAgente.Matricula = oPersona.matricula;
                            nuevoAgente.Grado = oPersona.grado;
                            nuevoAgente.Nombre = oPersona.nombre;
                            nuevoAgente.Distintivo = oPersona.distintivo;
                            nuevoAgente.Arma = oPersona.arma;
                            nuevoAgente.Existencia = oPersona.existencia;
                            bd.Agente.InsertOnSubmit(nuevoAgente);
                            bd.SubmitChanges();
                            respuesta += " Agente Insertado";
                        }
                        //Actualizar
                        else
                        {
                            Agente aux = bd.Agente.Where(p => p.Id_Agente == oPersona.id_Agente).First();
                            aux.Id_Agente = oPersona.id_Agente;
                            aux.Matricula = oPersona.matricula;
                            aux.Grado = oPersona.grado;
                            aux.Nombre = oPersona.nombre;
                            aux.Distintivo = oPersona.distintivo;
                            aux.Arma = oPersona.arma;
                            bd.SubmitChanges();
                            respuesta += "Agente Actualizado";
                        }
                        if (oPersona.id_Encargado == 0)
                        {
                            IEnumerable<EncargadoCLS> listaEncargado = (from usuario in bd.Encargado
                                                                   select new EncargadoCLS
                                                                   {
                                                                       id_Encargado = usuario.Id_Encargado
                                                                   }).ToList();

                            oPersona.id_Encargado = listaEncargado.Last().id_Encargado + 1;
                            Encargado nuevoEncargado = new Encargado();
                            nuevoEncargado.Id_Encargado = oPersona.id_Encargado;
                            nuevoEncargado.Tipo_Encargado = oPersona.tipo_Encargado;
                            nuevoEncargado.Pass = oPersona.pass;
                            nuevoEncargado.Id_Agente = oPersona.id_Agente;
                            bd.Encargado.InsertOnSubmit(nuevoEncargado);
                            bd.SubmitChanges();
                            respuesta += "Encargado insertado ";
                            

                        }
                        else
                        {
                            Encargado aux = bd.Encargado.Where(p => p.Id_Encargado == oPersona.id_Encargado).First();
                            aux.Id_Encargado = oPersona.id_Encargado;
                            aux.Tipo_Encargado = oPersona.tipo_Encargado;
                            aux.Pass = oPersona.pass;
                            aux.Id_Agente = oPersona.id_Agente;
                            bd.SubmitChanges();
                            respuesta = "Encargado Actualizado";
                            Agente aux1 = bd.Agente.Where(p => p.Id_Agente == oPersona.id_Agente).First();
                            aux1.Id_Agente = oPersona.id_Agente;
                            aux1.Matricula = oPersona.matricula;
                            aux1.Grado = oPersona.grado;
                            aux1.Nombre = oPersona.nombre;
                            aux1.Distintivo = oPersona.distintivo;
                            aux1.Arma = oPersona.arma;
                            bd.SubmitChanges();
                            respuesta += "Agente Actualizado";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;

            // return "Estos me enviaste"+oUsuario.id_Agente+" , " + oUsuario.matricula + " , " + oUsuario.grado + " , " + oUsuario.nombre + " , " + oUsuario.distintivo + " , " + oUsuario.arma + " , " + oUsuario.existencia;
    */
                
                }
    }
}
