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
    public class ActividadController : ApiController
    {
        [HttpGet]
        // localhost/api/Actividad
        public IEnumerable<ActividadCLS> listaActividad()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ActividadCLS> listarActividad = (from act in bd.Actividad
                                                   select new ActividadCLS
                                                   {
                                                       id_Actividad=act.Id_Actividad,
                                                       nombre=act.Nombre,
                                                       dificultad=act.Dificultad,
                                                       tipo=act.Tipo
                                                   }).ToList();
                return listarActividad;
            }
        }

        [HttpPut]
        public int eliminarActividad(int id_Actividad)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Actividad oActividad = bd.Actividad.Where(p => p.Id_Actividad == id_Actividad).First();
                    oActividad.Id_Actividad = 0;
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
        public int agregarActividad(Actividad oActividad)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oActividad.Id_Actividad == 0)
                    {
                        IEnumerable<ActividadCLS> listaActividad = (from act in bd.Actividad
                                                               where act.Id_Actividad != 0
                                                               select new ActividadCLS
                                                               {
                                                                   id_Actividad = act.Id_Actividad,
                                                                   nombre = act.Nombre,
                                                                   dificultad = act.Dificultad,
                                                                   tipo = act.Tipo
                                                               }).ToList();

                        oActividad.Id_Actividad = listaActividad.Count() + 1;
                        bd.Actividad.InsertOnSubmit(oActividad);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Actividad aux = bd.Actividad.Where(p => p.Id_Actividad == oActividad.Id_Actividad).First();
                        aux.Id_Actividad = oActividad.Id_Actividad;
                        aux.Nombre = oActividad.Nombre;
                        aux.Dificultad = oActividad.Dificultad;
                        aux.Tipo = oActividad.Tipo;
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
        public IEnumerable<ActividadCLS> recuperarActividad(int id_actividad)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ActividadCLS> listarActividad = (from act in bd.Actividad
                                                   where act.Id_Actividad == id_actividad
                                                   select new ActividadCLS
                                                   {
                                                       id_Actividad = act.Id_Actividad,
                                                       nombre = act.Nombre,
                                                       dificultad = act.Dificultad,
                                                       tipo = act.Tipo
                                                   }).ToList();
                return listarActividad;
            }
        }
    }
}
