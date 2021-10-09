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
    public class EvaluacionController : ApiController
    {

        [HttpGet]
         public EvaluacionCLS getEvaluacionFuncion(int id_funcion)
         {
             using (DBSedenaDataContext bd = new DBSedenaDataContext())
             {
                 
                 IEnumerable<EvaluacionCLS> evaluado = (from fun in bd.Funcion 
                                                join age in bd.Agente on fun.Id_Agente equals age.Id_Agente
                                                join tira in bd.Tirador on fun.Id_Funcion equals tira.Id_Funcion
                                                select new EvaluacionCLS
                                                {
                                                    id_funcion=fun.Id_Funcion,
                                                    nombre= age.Nombre,
                                                    matricula=age.Matricula,
                                                    disparos_Realizados=(int)tira.Disparos_Realizados,
                                                    disparos_Acertados=(int)tira.Disparos_Acertados,
                                                    disparos_Colateral=(int)tira.Disparos_Colateral,
                                                    bajas_Militares=(int)tira.Bajas_Militares,
                                                    bajas_Colaterales=(int)tira.Bajas_Colaterales,
                                                    bajas_Enemigos=(int)tira.Bajas_Enemigos
                                                    

                                                }).ToList();
                EvaluacionCLS final = new EvaluacionCLS();
                foreach (var x in evaluado) 
                {
                    if (x.id_funcion == id_funcion)
                    {
                        return x;
                        
                    }
                }
                 return final;

             }
         }


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
                                                           id_funcion = fun.Id_Funcion,
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
                                                           id_funcion = fun.Id_Funcion,
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
        public int agregarEvaluacion(EvaluacionCLS oEvaluacion)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {

                    AgenteCLS usu = bd.Agente.Where(p => p.Matricula == oEvaluacion.matricula)
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
                    oFuncion.Id_Funcion = listaFuncion.Count() + 1;
                    oFuncion.Id_Agente = usu.id_Agente;
                    oFuncion.Id_Sesion = 1;
                    oFuncion.Funcion1 = "Tirador";
                    bd.Funcion.InsertOnSubmit(oFuncion);
                    bd.SubmitChanges();

                    Tirador tiraaxu = new Tirador();

                    tiraaxu.Id_Arma = 1;
                    tiraaxu.Id_Funcion = oFuncion.Id_Funcion;
                    tiraaxu.Uso_Correcto = oEvaluacion.uso_Correcto;
                    tiraaxu.Mision_Cumplida = oEvaluacion.mision_Cumplida;
                    tiraaxu.Disparos_Realizados = oEvaluacion.disparos_Realizados;
                    tiraaxu.Disparos_Acertados = oEvaluacion.disparos_Acertados;
                    tiraaxu.Disparos_Colateral = oEvaluacion.disparos_Colateral;
                    tiraaxu.Bajas_Militares = oEvaluacion.bajas_Militares;
                    tiraaxu.Bajas_Colaterales = oEvaluacion.bajas_Colaterales;
                    tiraaxu.Bajas_Enemigos = oEvaluacion.bajas_Militares;



                    bd.Tirador.InsertOnSubmit(tiraaxu);
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
        

    }
}
