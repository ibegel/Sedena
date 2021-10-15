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
    public class EvaluacionController : ApiController
    {

        public int id_funcion;


        [HttpGet]
        public EvaluacionesCLS getEvaluacion()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {

                EvaluacionCLS[] evaluado = (from fun in bd.Funcion
                                                       join age in bd.Agente on fun.Id_Agente equals age.Id_Agente
                                                       join tira in bd.Tirador on fun.Id_Funcion equals tira.Id_Funcion
                                                       
                                                       select new EvaluacionCLS
                                                       {
                                                           funcion = fun.Funcion1,
                                                           nombre = age.Nombre,
                                                           matricula = age.Matricula,
                                                           disparosRealizados = (int)tira.Disparos_Realizados,
                                                           disparosAcertados = (int)tira.Disparos_Acertados,
                                                           disparosColateral = (int)tira.Disparos_Colateral,
                                                           bajasMilitares = (int)tira.Bajas_Militares,
                                                           bajasColaterales = (int)tira.Bajas_Colaterales,
                                                           bajasEnemigos = (int)tira.Bajas_Enemigos,
                                                           tiempo=(float)tira.Tiempo,



                                                       }).ToArray();
                EvaluacionesCLS final = new EvaluacionesCLS();
                final.lista = evaluado;
                
                return final;

            }
        }


        [HttpGet]
        public EvaluacionesCLS getEvaluacionMatricula(string matricula)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                
                IEnumerable<EvaluacionCLS> evaluado = (from fun in bd.Funcion
                                                       join age in bd.Agente on fun.Id_Agente equals age.Id_Agente
                                                       join tira in bd.Tirador on fun.Id_Funcion equals tira.Id_Funcion
                                                       select new EvaluacionCLS
                                                       {
                                                           funcion = fun.Funcion1,
                                                           nombre = age.Nombre,
                                                           matricula = age.Matricula,
                                                           disparosRealizados = (int)tira.Disparos_Realizados,
                                                           disparosAcertados = (int)tira.Disparos_Acertados,
                                                           disparosColateral = (int)tira.Disparos_Colateral,
                                                           bajasMilitares = (int)tira.Bajas_Militares,
                                                           bajasColaterales = (int)tira.Bajas_Colaterales,
                                                           bajasEnemigos = (int)tira.Bajas_Enemigos


                                                       }).ToList();
                EvaluacionesCLS final = new EvaluacionesCLS();
                List<EvaluacionCLS> aux = new List<EvaluacionCLS>();
             
                foreach (var x in evaluado)
                {
                    if (x.matricula == matricula)
                    {
                        aux.Add(x);

                    }
                }
                final.lista = aux.ToArray();
                return final;

            }
        }



        [HttpPost]
        public string agregarEvaluacion(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            string respuesta = "";
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    //Verificar Agente
                    AgenteCLS usu = bd.Agente.Where(p => p.Matricula == (string)json["matricula"])
                    .Select(p => new AgenteCLS
                    {
                        idAgente = p.Id_Agente,
                        matricula = p.Matricula
                    }
                    ).First();
                    int valx = 0;
                    List<EncargadoCLS> listarEncargado = (from encar in bd.Encargado
                                                          join usua in bd.Agente
                                                          on encar.Id_Agente equals usua.Id_Agente
                                                          select new EncargadoCLS
                                                          {
                                                              idEncargado = encar.Id_Encargado,
                                                              matricula = usua.Matricula,
                                                          }).ToList();
                    EncargadoCLS aux = new EncargadoCLS();
                    foreach (var a in listarEncargado)
                    {
                        if (a.matricula.Equals((string)json["matriculaEncargado"]))
                        {
                            valx = a.idEncargado;
                            break;
                        }
                    }
                    if (usu.idAgente != 0)
                    {

                        //Creacion de Sesion
                        Sesion oSesion = new Sesion();
                        IEnumerable<SesionCLS> listaSesion = (from ses in bd.Sesion
                                                                select new SesionCLS
                                                                {
                                                                    idSesion = ses.Id_Sesion
                                                                }).ToList();
                        oSesion.Id_Sesion = listaSesion.Last().idSesion + 1;
                        oSesion.Actividad = (string)json["actividad"];
                        oSesion.Entorno = (string)json["entorno"];
                        oSesion.Fecha = (string)json["fecha"];
                        oSesion.Id_Encargado = valx;
                        bd.Sesion.InsertOnSubmit(oSesion);
                        //Creacion de funcion
                        Funcion oFuncion = new Funcion();
                        IEnumerable<FuncionCLS> listaFuncion = (from funci in bd.Funcion
                                                                select new FuncionCLS
                                                                {
                                                                    idFuncion = funci.Id_Funcion
                                                                }).ToList();
                        oFuncion.Id_Funcion = listaFuncion.Last().idFuncion + 1;
                        oFuncion.Id_Agente = usu.idAgente;
                        oFuncion.Id_Sesion = oSesion.Id_Sesion;
                        oFuncion.Funcion1 = (string)json["funcion"];
                        bd.Funcion.InsertOnSubmit(oFuncion);
                        //Tirador o Conductor
                        if (oFuncion.Funcion1 == "Tirador")
                        {
                            Tirador tiraaxu = new Tirador();
                            tiraaxu.Id_Arma = 1;
                            tiraaxu.Id_Funcion = oFuncion.Id_Funcion;
                            tiraaxu.Uso_Correcto = (bool)json["usoCorrecto"];
                            tiraaxu.Mision_Cumplida = (bool)json["misionCumplida"];
                            tiraaxu.Disparos_Realizados = (int)json["disparosRealizados"];
                            tiraaxu.Disparos_Acertados = (int)json["disparosAcertados"];
                            tiraaxu.Disparos_Colateral = (int)json["disparosColateral"]; ;
                            tiraaxu.Bajas_Militares = (int)json["bajasMilitares"]; ;
                            tiraaxu.Bajas_Colaterales = (int)json["bajasColaterales"]; ;
                            tiraaxu.Bajas_Enemigos = (int)json["bajasEnemigos"]; 
                            tiraaxu.Tiempo = (float)json["tiempo"];
                            bd.Tirador.InsertOnSubmit(tiraaxu);
                        }
                        bd.SubmitChanges();
                        respuesta = "Agregado";
                    }
                    else
                    {
                        respuesta ="Hola";
                    }
                    
                    
                }
            }

            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
        

    }
}
