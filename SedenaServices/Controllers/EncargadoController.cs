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

    public class EncargadoController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<EncargadoCLS> listaEncargado()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<EncargadoCLS> listarEncargado = (from encar in bd.Encargado 
                                                             join usu in bd.Usuario
                                                             on encar.Id_Usuario equals usu.Id_Usuario
                                                             select new EncargadoCLS
                                                             {
                                                                 id_Encargado = encar.Id_Encargado,
                                                                 tipo_Encargado = encar.Tipo_Encargado,
                                                                 pass = encar.Pass,
                                                                 nombre=usu.Nombre
                                                             }).ToList();
                return listarEncargado;
            }
        }

        [HttpPut]
        public int eliminarEncargado(int id_encargado)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Encargado oEncargado = bd.Encargado.Where(p => p.Id_Encargado == id_encargado).First();
                    oEncargado.Tipo_Encargado = "Inhabilitado";
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
        public int agregarEncargado(int id_encargado,string tipo_encargado,string pass, int id_usuario)
        {
            Encargado oEncargado = new Encargado();
            oEncargado.Id_Encargado = id_encargado;
            oEncargado.Tipo_Encargado = tipo_encargado;
            oEncargado.Pass = pass;
            oEncargado.Id_Usuario = id_usuario;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oEncargado.Id_Encargado == 0)
                    {
                        IEnumerable<EncargadoCLS> listaEncargado = (from encarga in bd.Encargado
                                                                where encarga.Tipo_Encargado != "Inhabilitado"
                                                                  select new EncargadoCLS
                                                                {
                                                                    id_Encargado = encarga.Id_Encargado
                                                                }).ToList();

                        oEncargado.Id_Encargado = listaEncargado.Count() + 1;
                        bd.Encargado.InsertOnSubmit(oEncargado);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Encargado aux = bd.Encargado.Where(p => p.Id_Encargado == oEncargado.Id_Encargado).First();
                        aux.Id_Encargado = oEncargado.Id_Encargado;
                        aux.Tipo_Encargado = oEncargado.Tipo_Encargado;
                        aux.Pass = oEncargado.Pass;
                        aux.Id_Usuario = oEncargado.Id_Usuario;
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
        public EncargadoCLS recuperarEncargado(int id_Encargado)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EncargadoCLS oDoctor = bd.Encargado.Where(p => p.Id_Encargado == id_Encargado)
                    .Select(p => new EncargadoCLS
                    {

                        id_Encargado = p.Id_Encargado,
                        tipo_Encargado = p.Tipo_Encargado,
                        pass = p.Pass,
                        id_Usuario = (int)p.Id_Usuario
                    }
                    ).First();

                return oDoctor;


            }
        }
    }
}
