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
                                                           disparos_Realizados = (int)tira.Disparos_Realizados,
                                                           disparos_Acertados = (int)tira.Disparos_Acertados,
                                                           disparos_Colateral = (int)tira.Disparos_Colateral,
                                                           bajas_Militares = (int)tira.Bajas_Militares,
                                                           bajas_Colaterales = (int)tira.Bajas_Colaterales,
                                                           bajas_Enemigos = (int)tira.Bajas_Enemigos


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
                                                           disparos_Realizados = (int)tira.Disparos_Realizados,
                                                           disparos_Acertados = (int)tira.Disparos_Acertados,
                                                           disparos_Colateral = (int)tira.Disparos_Colateral,
                                                           bajas_Militares = (int)tira.Bajas_Militares,
                                                           bajas_Colaterales = (int)tira.Bajas_Colaterales,
                                                           bajas_Enemigos = (int)tira.Bajas_Enemigos


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

                    AgenteCLS usu = bd.Agente.Where(p => p.Matricula == (string)json["matricula"])
                    .Select(p => new AgenteCLS
                    {
                        id_Agente = p.Id_Agente,
                        matricula = p.Matricula
                    }
                    ).First();
                    Funcion oFuncion = new Funcion();


                    IEnumerable<FuncionCLS> listaFuncion = (from funci in bd.Funcion
                                                            select new FuncionCLS
                                                            {
                                                                id_Funcion = funci.Id_Funcion,
                                                            }).ToList();
                    oFuncion.Id_Funcion = listaFuncion.Last().id_Funcion + 1;
                    oFuncion.Id_Agente = usu.id_Agente;
                    oFuncion.Id_Sesion = 1;
                    oFuncion.Funcion1 = (string)json["funcion"];
                    bd.Funcion.InsertOnSubmit(oFuncion);
                    bd.SubmitChanges();
                    if (oFuncion.Funcion1 == "Tirador")
                    {
                        Tirador tiraaxu = new Tirador();
                        tiraaxu.Id_Arma = 1;
                        tiraaxu.Id_Funcion = oFuncion.Id_Funcion;
                        tiraaxu.Uso_Correcto = (bool)json["uso_Correcto"];
                        tiraaxu.Mision_Cumplida = (bool)json["mision_Cumplida"];
                        tiraaxu.Disparos_Realizados = (int)json["disparos_Realizados"];
                        tiraaxu.Disparos_Acertados = (int)json["disparos_Acertados"];
                        tiraaxu.Disparos_Colateral = (int)json["disparos_Colateral"]; ;
                        tiraaxu.Bajas_Militares = (int)json["bajas_Militares"]; ;
                        tiraaxu.Bajas_Colaterales = (int)json["bajas_Colaterales"]; ;
                        tiraaxu.Bajas_Enemigos = (int)json["bajas_Enemigos"]; ;
                        bd.Tirador.InsertOnSubmit(tiraaxu);
                    }
                    bd.SubmitChanges();
                    respuesta = "Agregado";
                }
            }

            catch (Exception ex)
            {
                respuesta = (string)json["matricula"];
            }
            return respuesta;
        }
        

    }
}
