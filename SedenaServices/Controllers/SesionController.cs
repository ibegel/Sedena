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
    public class SesionController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<SesionCLS> listaSesion()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<SesionCLS> listaSesion = (from sesion in bd.Sesion
                                                      
                                                      select new SesionCLS
                                                      {
                                                          id_Sesion= sesion.Id_Sesion,
                                                          id_Actividad=(int)sesion.Id_Actividad,
                                                          entorno=sesion.Entorno,
                                                          fecha=sesion.Fecha,
                                                          id_Encargado=(int)sesion.Id_Encargado
                                                      }).ToList();
                return listaSesion;
            }
        }

        [HttpPut]
        public int eliminarSesion(int id_sesion)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Sesion oSesion = bd.Sesion.Where(p => p.Id_Sesion == id_sesion).First();
                    oSesion.Id_Sesion = 0;
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
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarSesion(Sesion oSesion)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oSesion.Id_Sesion == 0)
                    {
                            IEnumerable<SesionCLS> listaSesion = (from ses in bd.Sesion
                                                                        where ses.Id_Actividad != 0
                                                                        select new SesionCLS
                                                                        {
                                                                            id_Sesion = ses.Id_Sesion,
                                                                        }).ToList();
                            oSesion.Id_Sesion = listaSesion.Count() + 1;
                            bd.Sesion.InsertOnSubmit(oSesion);
                            bd.SubmitChanges();
                            respuesta = 1;
                    }
                    else
                    {
                        Sesion aux = bd.Sesion.Where(p => p.Id_Sesion == oSesion.Id_Sesion).First();
                        aux.Id_Sesion = oSesion.Id_Sesion;
                        aux.Id_Actividad = oSesion.Id_Actividad;
                        aux.Entorno = oSesion.Entorno;
                        aux.Fecha = oSesion.Fecha;
                        aux.Id_Encargado = oSesion.Id_Encargado;
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
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
        public SesionCLS recuperarSesion(int id_sesion)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                SesionCLS oSesion = bd.Sesion.Where(p => p.Id_Sesion == id_sesion)
                    .Select(p => new SesionCLS
                    {
                        
                        id_Sesion=p.Id_Sesion,
                        id_Actividad=(int)p.Id_Actividad,
                        entorno=p.Entorno,
                        fecha=p.Fecha,
                        id_Encargado=(int)p.Id_Encargado
                    }
                    ).First();

                return oSesion;


            }
        }

    }
}
