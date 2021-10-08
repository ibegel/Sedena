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
    public class TiradorController : ApiController
    {
        [HttpGet]
        public IEnumerable<TiradorCLS> listaTirador()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<TiradorCLS> listarTirador = (from tira in bd.Tirador
                                                         select new TiradorCLS
                                                         {
                                                                 id_Funcion = (int)tira.Id_Funcion,
                                                                 id_Arma = (int)tira.Id_Arma,
                                                                 disparos_Realizados=(int)tira.Disparos_Realizados,
                                                                 disparos_Acertados=(int)tira.Disparos_Acertados,
                                                                 disparos_Colateral=(int)tira.Disparos_Colateral,
                                                                 bajas_Colaterales=(int)tira.Bajas_Colaterales,
                                                                 bajas_Enemigos=(int)tira.Bajas_Enemigos,
                                                                 bajas_Militares=(int)tira.Bajas_Militares,

                                                                 uso_Correcto=(bool)tira.Uso_Correcto,
                                                                 mision_Cumplida=(bool)tira.Mision_Cumplida
                                                             }).ToList();
                return listarTirador;
            }
        }

        [HttpPut]
        public int eliminarTirador(int id_Funcion)
        {
            int respuesta = 0;


            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarTirador(Tirador oTirador)
        {
           
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    bd.Tirador.InsertOnSubmit(oTirador);
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

        // localhost/api/Doctor/?iidDoctor=
        [HttpGet]
        public IEnumerable<TiradorCLS> RecuperarTirador(int id_Funcion)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<TiradorCLS> listarTirador = (from tira in bd.Tirador
                                                         where tira.Id_Funcion == id_Funcion 
                                                         select new TiradorCLS
                                                             {
                                                                 id_Funcion = (int)tira.Id_Funcion,
                                                                 id_Arma = (int)tira.Id_Arma,
                                                             disparos_Realizados = (int)tira.Disparos_Realizados,
                                                             disparos_Acertados = (int)tira.Disparos_Acertados,
                                                             disparos_Colateral = (int)tira.Disparos_Colateral,
                                                             bajas_Colaterales = (int)tira.Bajas_Colaterales,
                                                             bajas_Enemigos = (int)tira.Bajas_Enemigos,
                                                             bajas_Militares = (int)tira.Bajas_Militares,
                                                             uso_Correcto = (bool)tira.Uso_Correcto,
                                                             mision_Cumplida = (bool)tira.Mision_Cumplida
                                                         }).ToList();
                return listarTirador;
            }
        }
    }
}
