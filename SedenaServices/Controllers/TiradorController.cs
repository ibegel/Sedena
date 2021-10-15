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
                                                                 idFuncion = (int)tira.Id_Funcion,
                                                                 idArma = (int)tira.Id_Arma,
                                                                 disparosRealizados=(int)tira.Disparos_Realizados,
                                                                 disparosAcertados=(int)tira.Disparos_Acertados,
                                                                 disparosColateral=(int)tira.Disparos_Colateral,
                                                                 bajasColaterales=(int)tira.Bajas_Colaterales,
                                                                 bajasEnemigos=(int)tira.Bajas_Enemigos,
                                                                 bajasMilitares=(int)tira.Bajas_Militares,
                                                                 usoCorrecto=(bool)tira.Uso_Correcto,
                                                                 misionCumplida=(bool)tira.Mision_Cumplida
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
                                                                 idFuncion = (int)tira.Id_Funcion,
                                                                 idArma = (int)tira.Id_Arma,
                                                             disparosRealizados = (int)tira.Disparos_Realizados,
                                                             disparosAcertados = (int)tira.Disparos_Acertados,
                                                             disparosColateral = (int)tira.Disparos_Colateral,
                                                             bajasColaterales = (int)tira.Bajas_Colaterales,
                                                             bajasEnemigos = (int)tira.Bajas_Enemigos,
                                                             bajasMilitares = (int)tira.Bajas_Militares,
                                                             usoCorrecto = (bool)tira.Uso_Correcto,
                                                             misionCumplida = (bool)tira.Mision_Cumplida
                                                         }).ToList();
                return listarTirador;
            }
        }
    }
}
