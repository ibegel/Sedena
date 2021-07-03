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
    public class VehiculoController : ApiController
    {

        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<VehiculoCLS> listavehiculo()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<VehiculoCLS> listarVehiculo = (from veh in bd.Vehiculo
                                                   select new VehiculoCLS
                                                   {
                                                       id_Vehiculo = (int)veh.Id_Vehiculo,
                                                       caracteristicas = veh.Caracteristicas
                                                   }).ToList();
                return listarVehiculo;
            }
        }

        [HttpPut]
        public int eliminarVehiculo(int id_vehiculo)
        {
            int respuesta = 0;
            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarvehiculo(int id_vehiculo, string caracteristicas)
        {
            Vehiculo oVehiculo = new Vehiculo();
            oVehiculo.Id_Vehiculo = id_vehiculo;
            oVehiculo.Caracteristicas = caracteristicas;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    bd.Vehiculo.InsertOnSubmit(oVehiculo);
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
        public IEnumerable<VehiculoCLS> RecuperarVehiculo(int id_vehiculo)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<VehiculoCLS> listarVehiculo = (from veh in bd.Vehiculo
                                                   where veh.Id_Vehiculo == id_vehiculo
                                                   select new VehiculoCLS
                                                   {
                                                       id_Vehiculo = veh.Id_Vehiculo,
                                                       caracteristicas = veh.Caracteristicas
                                                   }).ToList();
                return listarVehiculo;
            }
        }
    }
}
