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
                IEnumerable<SesionCLS> listaDoctor = (from sesion in bd.Sesion
                                                      
                                                      select new SesionCLS
                                                      {
                                                          id_Sesion= sesion.Id_Sesion,
                                                          tipo_Sesion=sesion.Tipo_Sesion,
                                                          entorno=sesion.Entorno,
                                                          fecha=sesion.Fecha,
                                                          id_Encargado=(int)sesion.Id_Encargado
                                                      }).ToList();
                return listaDoctor;
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
                    oSesion.Tipo_Sesion = "Borrada";
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
        public int agregarSesion(int id_sesion, string tipo_sesion,string entorno, string fecha,int id_encargado)
        {
            Sesion oSesion = new Sesion();
            oSesion.Id_Sesion = id_sesion;
            oSesion.Tipo_Sesion = tipo_sesion;
            oSesion.Entorno = entorno;
            oSesion.Fecha = fecha;
            oSesion.Id_Encargado = id_encargado;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oSesion.Id_Sesion == 0)
                    {
                            IEnumerable<SesionCLS> listaSesion = (from ses in bd.Sesion
                                                                        where ses.Tipo_Sesion != "Borrada"
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
                        aux.Tipo_Sesion = oSesion.Tipo_Sesion;
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
                        tipo_Sesion=p.Tipo_Sesion,
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
