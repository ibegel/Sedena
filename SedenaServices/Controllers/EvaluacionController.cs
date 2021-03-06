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
    //Controlador que manaja la forma de evaluacion que sera dividida en multiples tablas (sesion, funcion, tirador y conductor)
    //verificando que los campos que se ingresan tengan coherencia con los campos que ya existen 
    public class EvaluacionController : ApiController
    {
        //Recupera una lista con todas las evaluaciones que se han realizado actualmente
        //tomando en cuanta las tablas agente funcion sesion tirador o conductor segun sea el caso
        //Primero recupera todas las evaluaciones del campo tirador y las agrega a una lista que nos servira como auxilar 
        //Despues recupera todas las evaluaciones del campo conductor y las agrega a otra lista auxiliar
        //Finalmente las agrega a una lista final que sera enviada como respuesta a el usuario del simulador 
        [HttpGet]
        public EvaluacionesCLS getEvaluacion()
        {
            EvaluacionesCLS final = new EvaluacionesCLS();

            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {

                EvaluacionCLS[] evaluado = (from fun in bd.Funcion
                                                       join age in bd.Agente on fun.Id_Agente equals age.Id_Agente
                                                       join tira in bd.Tirador on fun.Id_Funcion equals tira.Id_Funcion
                                                       join ses in bd.Sesion on fun.Id_Sesion equals ses.Id_Sesion
                                                       

                                            select new EvaluacionCLS
                                                       {
                                                           funcion = fun.Funcion1,
                                                           nombre = age.Nombre,
                                                           matricula = age.Matricula,
                                                           usoCorrecto=(bool)tira.Uso_Correcto,
                                                           misionCumplida=(bool)tira.Mision_Cumplida,
                                                           disparosRealizados = (int)tira.Disparos_Realizados,
                                                           disparosAcertados = (int)tira.Disparos_Acertados,
                                                idEncargado = (int)ses.Id_Encargado,
                                                disparosColateral = (int)tira.Disparos_Colateral,
                                                           bajasMilitares = (int)tira.Bajas_Militares,
                                                           bajasColaterales = (int)tira.Bajas_Colaterales,
                                                           bajasEnemigos = (int)tira.Bajas_Enemigos,
                                                           tiempo=(float)tira.Tiempo,
                                                           actividad=ses.Actividad,
                                                           entorno= ses.Entorno,
                                                           fecha=ses.Fecha,
                                                          
                                            }).ToArray();
                for (int x = 0; x < evaluado.Length; x++)
                {
                    EncargadoCLS listarEncargado = (from encar in bd.Encargado
                                                    join usu in bd.Agente
                                                    on encar.Id_Agente equals usu.Id_Agente
                                                    where encar.Id_Encargado == evaluado[x].idEncargado
                                                    select new EncargadoCLS
                                                    {
                                                        matricula = usu.Matricula
                                                    }).First();
                    evaluado[x].matriculaEncargado = listarEncargado.matricula;
                }

                foreach (var x in evaluado)
                {
                    final.lista.Add(x);
                }
            }
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {

                EvaluacionCLS[] evaluado = (from fun in bd.Funcion
                                            join age in bd.Agente on fun.Id_Agente equals age.Id_Agente
                                            join con in bd.Conductor on fun.Id_Funcion equals con.Id_Funcion
                                            join ses in bd.Sesion on fun.Id_Sesion equals ses.Id_Sesion

                                            select new EvaluacionCLS
                                            {
                                                funcion = fun.Funcion1,
                                                nombre = age.Nombre,
                                                matricula = age.Matricula,
                                                usoCorrecto = (bool)con.Uso_Correcto,
                                                idEncargado=(int)ses.Id_Encargado,
                                                misionCumplida = (bool)con.Mision_Cumplida,
                                                colisiones=(int)con.Colisiones,
                                                tiempo = (float)con.Tiempo,
                                                actividad = ses.Actividad,
                                                entorno = ses.Entorno,
                                                fecha = ses.Fecha,
                                            }).ToArray();
                for (int x = 0; x < evaluado.Length; x++)
                {
                    EncargadoCLS listarEncargado = (from encar in bd.Encargado
                                                    join usu in bd.Agente
                                                    on encar.Id_Agente equals usu.Id_Agente
                                                    where encar.Id_Encargado == evaluado[x].idEncargado
                                                    select new EncargadoCLS
                                                    {
                                                        matricula = usu.Matricula
                                                    }).First();
                    evaluado[x].matriculaEncargado = listarEncargado.matricula;
                }

                foreach (var x in evaluado)
                {
                    final.lista.Add(x);
                }


            }
            return final;
        }


        //Controlador del flujo de entrada de datos en las tablas sesion, funcion, tirador, conductor
        //Primero recupera todos los datos existentes en la tabla Agente para asi corroborar la existencia del agente evaluado
        //Si no existe retorna una cadena para decir que el agente no existe
        //Se repite lo mismo con la matricula del encargado 
        //Ya verificados los datos empezamos a segmentar los campos en las tablas sesion y funcion 
        //Los datos finales seran enviados a la tabla conductor o a la tabla conductor segun el campo funcion lo verifique 
        //finalmente se agregan los campos en la base de datos y enviamos el mensaje de exito 
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
                        if (oFuncion.Funcion1 == "Conductor")
                        {
                            Conductor conducaxu = new Conductor();
                            conducaxu.Id_Funcion = oFuncion.Id_Funcion;
                            conducaxu.Uso_Correcto = (bool)json["usoCorrecto"];
                            conducaxu.Mision_Cumplida = (bool)json["misionCumplida"];
                            conducaxu.Colisiones = (int)json["colisiones"];
                            conducaxu.Tiempo = (float)json["tiempo"];
                            bd.Conductor.InsertOnSubmit(conducaxu);
                        }
                        bd.SubmitChanges();
                        respuesta = "Agregado";
                    }
                    else
                    {
                        respuesta ="El agente no existe";
                    }
                    
                    
                }
            }

            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

      /* [HttpGet]
        public LogrosCLS puntuaciones(string campoEvaluacion)
        {
            LogrosCLS cal = new LogrosCLS();
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                cal.listaTiradores = (from tira in bd.Tirador
                                      select new TiradorCLS
                                      {
                                          idFuncion = (int)tira.Id_Funcion,
                                          disparosRealizados = (int)tira.Disparos_Realizados,
                                          disparosAcertados = (int)tira.Disparos_Acertados,
                                          disparosColateral = (int)tira.Disparos_Colateral,
                                          bajasColaterales = (int)tira.Bajas_Colaterales,
                                          bajasEnemigos = (int)tira.Bajas_Enemigos,
                                          bajasMilitares = (int)tira.Bajas_Militares,
                                          usoCorrecto = (bool)tira.Uso_Correcto,
                                          misionCumplida = (bool)tira.Mision_Cumplida
                                      }).ToArray(); 
                cal.listaConductores = (from conduc in bd.Conductor
                                                       select new ConductorCLS
                                                       {
                                                           idFuncion = (int)conduc.Id_Funcion,
                                                           colisiones = (int)conduc.Colisiones,
                                                           tiempo = (int)conduc.Tiempo,
                                                           misionCumplida = (bool)conduc.Mision_Cumplida,
                                                           usoCorrecto = (bool)conduc.Uso_Correcto

                                                       }).ToArray();
            }
            return cal;
        }
       */

        

    }
}
