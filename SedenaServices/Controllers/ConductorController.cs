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
    public class ConductorController : ApiController
    {
        [HttpGet]
        public IEnumerable<ConductorCLS> listaConductor()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ConductorCLS> listarConductor = (from conduc in bd.Conductor
                                                         select new ConductorCLS
                                                         {
                                                             id_Funcion = (int)conduc.Id_Funcion,
                                                             id_Vehiculo = (int)conduc.Id_Vehiculo,
                                                         }).ToList();
                return listarConductor;
            }
        }

        [HttpPut]
        public int eliminarConductor(int id_Funcion)
        {
            int respuesta = 0;


            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarConductor(Conductor oConductor)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    bd.Conductor.InsertOnSubmit(oConductor);
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
        public IEnumerable<ConductorCLS> RecuperarConductor(int id_Funcion)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<ConductorCLS> listarConductor = (from conduc in bd.Conductor
                                                         where conduc.Id_Funcion == id_Funcion
                                                         select new ConductorCLS
                                                         {
                                                             id_Funcion = (int)conduc.Id_Funcion,
                                                             id_Vehiculo = (int)conduc.Id_Vehiculo,
                                                         }).ToList();
                return listarConductor;
            }
        }
    }
}
