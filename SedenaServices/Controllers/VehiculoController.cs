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
                                                               placa = veh.Placa,
                                                               color = veh.Color,
                                                               marca = veh.Marca,
                                                               nombre = veh.Nombre
                                                           })
                .ToList();
                return listarVehiculo;
            }
        }

        [HttpPut]
        public int eliminarVehiculo(int id_Vehiculo)
        {
            int respuesta = 0;
            return respuesta;

        }
        // localhost/api/Doctor/
        [HttpPost]
        public int agregarvehiculo(Vehiculo oVehiculo)
        {
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
        public IEnumerable<VehiculoCLS> RecuperarVehiculo(int id_Vehiculo)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<VehiculoCLS> listarVehiculo = (from veh in bd.Vehiculo
                                                   where veh.Id_Vehiculo == id_Vehiculo
                                                   select new VehiculoCLS
                                                   {
                                                       id_Vehiculo = (int)veh.Id_Vehiculo,
                                                       placa = veh.Placa,
                                                       color = veh.Color,
                                                       marca = veh.Marca
                                                   }).ToList();
                return listarVehiculo;
            }
        }
    }
}
