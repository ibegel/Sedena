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
    public class Catalogo_ITController : ApiController
    {
        [HttpGet]
        // localhost/api/Actividad
        public IEnumerable<Catalogo_ITCLS> listaCatalogo_IT()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Catalogo_ITCLS> listarCatalogo = (from cat in bd.Catalogo_IT
                                                              select new Catalogo_ITCLS
                                                              {
                                                                  id_Incidente = cat.Id_Incidente,
                                                                  nombre = cat.Nombre,
                                                              }).ToList();
                return listarCatalogo;
            }
        }

        [HttpPut]
        public int eliminarCatalogo_IT(int id_Incidente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Catalogo_IT oCatalogo = bd.Catalogo_IT.Where(p => p.Id_Incidente == id_Incidente).First();
                    oCatalogo.Nombre = null;
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
        public int agregarCatalogo(Catalogo_IT oCatalogo)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oCatalogo.Id_Incidente == 0)
                    {
                        IEnumerable<Catalogo_ITCLS> listaCatalogo = (from cat in bd.Catalogo_IT
                                                                     where cat.Nombre != null
                                                                     select new Catalogo_ITCLS
                                                                     {
                                                                         id_Incidente = cat.Id_Incidente,
                                                                         nombre = cat.Nombre,
                                                                     }).ToList();

                        oCatalogo.Id_Incidente = listaCatalogo.Count() + 1;
                        bd.Catalogo_IT.InsertOnSubmit(oCatalogo);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Catalogo_IT aux = bd.Catalogo_IT.Where(p => p.Id_Incidente == oCatalogo.Id_Incidente).First();
                        aux.Id_Incidente = oCatalogo.Id_Incidente;
                        aux.Nombre = oCatalogo.Nombre;
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
        public IEnumerable<Catalogo_ITCLS> recuperarCatalogo(int id_Incidente)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Catalogo_ITCLS> listarCatalogo = (from cat in bd.Catalogo_IT
                                                              where cat.Id_Incidente == id_Incidente
                                                              select new Catalogo_ITCLS
                                                              {
                                                                  id_Incidente = cat.Id_Incidente,
                                                                  nombre = cat.Nombre,
                                                              }).ToList();
                return listarCatalogo;
            }
        }
    }
}
