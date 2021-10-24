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

    //Este script controla el flujo de entrada de datos en la tabla de Agente 
    //Sirve como intermediario entre la base de datos y la web api 
    //Proporciona un mejor control de flujo de datos ademas que cuenta con restricciones por cada una de las peticiones 
    public class AgenteController : ApiController
    {

        //Este controlador se utiliza para acceder a la base de datos y de ella recuperar todos los agentes 
        //No requiere ninguno tipo de dato de entrada para poder acceder a el 
        //Los agentes recuperados son colocados es una lista donde seran enviados en forma de json
 
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
        //El controlador de borrado en la tabla agente 
        //Para acceder a el debemos de proporcionar el identificador del agente el cual sera borrado 
        //Buscara algun agente que cumpla con el id proporcionado y lo borrara
        //En caso de que el agente no exista proporcionara una respuesta igual a 0 
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
        //Controlador de flujo de entrada de datos dentro de la tabla agente 
        //Transforma los datos que se le entregan a un Json para un mejor manejo de los mismos
        //Busca dentro de los campos existentes un agente que ya tenga los mismos valores en la matricula 
        //Si la matricula es encontrada y concuerda con el id tambien proporcionado, entonces se actualiza los valores existentes
        //Si la matricula es encontrada y no concuerda el id entonces se manda un aviso donde se menciona que la matricula ya esta en existencia
        //Si la matricula no fue encontrada entonces se ingresa como un agente nuevo y se le asignan los datos proporcionados
        //
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
        //Controlador que retorna un agente especifico que cumpla la caracteristicas 
        //Se solicita el id del agente 
        //hacemos una peticion de los campos en la tabla Agente 
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios
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

        //Controlador que retorna un agente especifico que cumpla la caracteristicas 
        //Se solicita el nombre del agente
        //hacemos una peticion de los campos en la tabla Agente 
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios

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

        //Controlador que retorna un agente especifico que cumpla la caracteristicas 
        //Se solicita el distintivo del agente
        //hacemos una peticion de los campos en la tabla Agente 
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios
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

        //Controlador que retorna un agente especifico que cumpla la caracteristicas 
        //Se solicita la matricula del agente
        //hacemos una peticion de los campos en la tabla Agente 
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios

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
