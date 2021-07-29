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
    public class DisparoController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<DisparoCLS> listaDisparo()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<DisparoCLS> listarDisparo = (from dispa in bd.Disparo
                                                      select new DisparoCLS
                                                      {                                                      
                                                          id_Funcion=(int)dispa.Id_Funcion,
                                                          id_Arma=(int)dispa.Id_Arma,
                                                          puntuacion=dispa.Puntuacion,
                                                          anomalias=dispa.Anomalias

                                                      }).ToList();
                return listarDisparo;
            }
        }

        [HttpPut]
        public int eliminarDisparo(int id_Disparo)
        {
            int respuesta = 0;
            

            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarDisparo(int id_funcion, int id_arma, string puntuacion, string anomalias)
        {
            Disparo oDisparo = new Disparo();
            oDisparo.Id_Funcion = id_funcion;
            oDisparo.Id_Arma = id_arma;
            oDisparo.Puntuacion = puntuacion;
            oDisparo.Anomalias = anomalias;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                        bd.Disparo.InsertOnSubmit(oDisparo);
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
        public IEnumerable<DisparoCLS> RecuperarDisparo(int id_Funcion,int id_Arma)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<DisparoCLS> listarDisparo = (from dispa in bd.Disparo
                                                         where dispa.Id_Funcion ==id_Funcion &&
                                                         dispa.Id_Arma==id_Arma
                                                         select new DisparoCLS
                                                         {
                                                             id_Funcion = (int)dispa.Id_Funcion,
                                                             id_Arma = (int)dispa.Id_Arma,
                                                             puntuacion = dispa.Puntuacion,
                                                             anomalias = dispa.Anomalias

                                                         }).ToList();
                return listarDisparo;
            }
        }

    }
}
