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
    public class Catalogo_ICController : ApiController
    {
        [HttpGet]
        // localhost/api/Actividad
        public IEnumerable<Catalogo_ICCLS> listaCatalogo_IC()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Catalogo_ICCLS> listarCatalogo = (from cat in bd.Catalogo_IC
                                                             select new Catalogo_ICCLS
                                                             {
                                                                 id_Incidente = cat.Id_Incidente,
                                                                 nombre = cat.Nombre,
                                                             }).ToList();
                return listarCatalogo;
            }
        }

        [HttpPut]
        public int eliminarCatalogo_IC(int id_Incidente)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Catalogo_IC oCatalogo = bd.Catalogo_IC.Where(p => p.Id_Incidente == id_Incidente).First();
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
        public int agregarCatalogo(Catalogo_IC oCatalogo)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oCatalogo.Id_Incidente == 0)
                    {
                        IEnumerable<Catalogo_ICCLS> listaCatalogo = (from cat in bd.Catalogo_IC
                                                                    where cat.Nombre != null
                                                                    select new Catalogo_ICCLS
                                                                    {
                                                                        id_Incidente = cat.Id_Incidente,
                                                                        nombre = cat.Nombre,
                                                                    }).ToList();

                        oCatalogo.Id_Incidente = listaCatalogo.Count() + 1;
                        bd.Catalogo_IC.InsertOnSubmit(oCatalogo);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Catalogo_IC aux = bd.Catalogo_IC.Where(p => p.Id_Incidente == oCatalogo.Id_Incidente).First();
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
        public IEnumerable<Catalogo_ICCLS> recuperarCatalogo(int id_incidente)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<Catalogo_ICCLS> listarCatalogo = (from cat in bd.Catalogo_IC
                                                             where cat.Id_Incidente == id_incidente
                                                             select new Catalogo_ICCLS
                                                             {
                                                                 id_Incidente=cat.Id_Incidente,
                                                                 nombre = cat.Nombre,
                                                             }).ToList();
                return listarCatalogo;
            }
        }
    }
}
