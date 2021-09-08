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
    public class Incidentes_ConductorController : ApiController
    {

        [HttpGet]
        // localhost/api/Actividad
        public IEnumerable<Incidentes_ConductorCLS> listaIncidente_IC()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Incidentes_ConductorCLS> listarIncidentes = (from inci in bd.Incidentes_Conductor
                                                              select new Incidentes_ConductorCLS
                                                              {
                                                                  id_Incidente = (int)inci.Id_Incidente,
                                                                  id_Funcion=(int)inci.Id_Funcion,
                                                                  numero_Incidente=(int)inci.Numero_Incidente
                                                              }).ToList();
                return listarIncidentes;
            }
        }

        [HttpPut]
        public int eliminarIncidente(int id_Incidente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Incidentes_Conductor oIncidente = bd.Incidentes_Conductor.Where(p => p.Id_Incidente == id_Incidente).First();
                    oIncidente.Id_Incidente = 0;
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
        public int agregarIncidente(Incidentes_Conductor oIncidente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oIncidente.Id_Incidente == 0)
                    {
                        IEnumerable<Incidentes_ConductorCLS> listaIncidentes = (from inci in bd.Incidentes_Conductor
                                                                     where inci.Id_Incidente != 0
                                                                     select new Incidentes_ConductorCLS
                                                                     {
                                                                         id_Incidente = (int)inci.Id_Incidente,
                                                                         id_Funcion = (int)inci.Id_Funcion,
                                                                         numero_Incidente = (int)inci.Numero_Incidente
                                                                     }).ToList();

                        oIncidente.Id_Incidente = listaIncidentes.Count() + 1;
                        bd.Incidentes_Conductor.InsertOnSubmit(oIncidente);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Incidentes_Conductor aux = bd.Incidentes_Conductor.Where(p => p.Id_Incidente == oIncidente.Id_Incidente).First();
                        aux.Id_Incidente = oIncidente.Id_Incidente;
                        aux.Id_Funcion = oIncidente.Id_Funcion;
                        aux.Numero_Incidente = oIncidente.Numero_Incidente;
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
        public IEnumerable<Incidentes_ConductorCLS> recuperarIncidente(int id_Incidente)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Incidentes_ConductorCLS> listarIncidentes = (from inci in bd.Incidentes_Conductor
                                                              where inci.Id_Incidente == id_Incidente
                                                              select new Incidentes_ConductorCLS
                                                              {
                                                                  id_Incidente = (int)inci.Id_Incidente,
                                                                  id_Funcion = (int)inci.Id_Funcion,
                                                                  numero_Incidente = (int)inci.Numero_Incidente
                                                              }).ToList();
                return listarIncidentes;
            }
        }
    }
}
