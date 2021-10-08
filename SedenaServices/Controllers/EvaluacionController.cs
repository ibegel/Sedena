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

        /* [HttpGet]
         public EvaluacionesCLS listaAgente()
         {
             using (DBSedenaDataContext bd = new DBSedenaDataContext())
             {
                 EvaluacionesCLS lista = new EvaluacionesCLS();
                 List<EvaluacionCLS> listaAgente = (from age in bd.Agente 
                                                join fun in bd.Funcion on age.Id_Agente equals fun.Id_Agente
                                                join tira in bd.Tirador on fun.Id_Funcion equals tira.Id_Funcion
                                                join inci in bd.Incidentes_Tirador on tira.Id_Funcion equals inci.Id_Funcion
                                                join cat in bd.Catalogo_IT on 
                                                select new EvaluacionCLS
                                                {
                                                    nombre= age.Nombre,
                                                    matricula=age.Matricula,
                                                    disparos_Realizados=inci.

                                                }).ToList();
                 lista.lista = listaAgente.ToArray();
                 return lista;

             }
         }*/
        
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
                                                            where funci.Funcion1 != "Inhabilitado"
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
