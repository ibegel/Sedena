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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        // localhost/api/Doctor
        public IEnumerable<UsuarioCLS> listaUsuario()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                IEnumerable<UsuarioCLS> listaUsuario = (from usuario in bd.Usuario
                                                        where usuario.Clave!=null
                                                      select new UsuarioCLS
                                                      {
                                                          id_Usuario=usuario.Id_Usuario,
                                                          clave=usuario.Clave,
                                                          rango=usuario.Rango,
                                                          nombre=usuario.Nombre,
                                                          url=usuario.Url
                                                      }).ToList();
                return listaUsuario;
            }
        }

        [HttpPut]
        public int eliminarUsuario(int id_Usuario)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Usuario oUsuario = bd.Usuario.Where(p => p.Id_Usuario == id_Usuario).First();
                    oUsuario.Clave = null;
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


        [HttpPost]
        public int agregarUsuario(int id_usuario , string clave ,string rango,string nombre,string url)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Id_Usuario = id_usuario;
            oUsuario.Clave = clave;
            oUsuario.Rango = rango;
            oUsuario.Nombre = nombre;
            oUsuario.Url = url;
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    if (oUsuario.Id_Usuario == 0)
                    {
                        IEnumerable<UsuarioCLS> listaUsuario = (from usuario in bd.Usuario
                                                                where usuario.Clave != null
                                                                select new UsuarioCLS
                                                                {
                                                                    id_Usuario = usuario.Id_Usuario,
                                                                    clave = usuario.Clave,
                                                                    rango = usuario.Rango,
                                                                    nombre = usuario.Nombre,
                                                                    url=usuario.Url
                                                                }).ToList();

                        oUsuario.Id_Usuario = listaUsuario.Count()+1;
                        bd.Usuario.InsertOnSubmit(oUsuario);
                        bd.SubmitChanges();
                        respuesta = 1;
                    }
                    else
                    {
                        Usuario aux = bd.Usuario.Where(p => p.Id_Usuario == oUsuario.Id_Usuario).First();
                        aux.Id_Usuario = oUsuario.Id_Usuario;
                        aux.Clave = oUsuario.Clave;
                        aux.Rango = oUsuario.Rango;
                        aux.Nombre = oUsuario.Nombre;
                        aux.Url = oUsuario.Url;
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
        
        [HttpGet]
        public UsuarioCLS recuperarUsuario(int id_Usuario)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                UsuarioCLS oUsuario = bd.Usuario.Where(p => p.Id_Usuario == id_Usuario)
                    .Select(p => new UsuarioCLS
                    {
                        id_Usuario=p.Id_Usuario,
                        clave=p.Clave,
                        rango=p.Rango,
                        nombre=p.Nombre,
                        url=p.Url
                    }
                    ).First();

                return oUsuario;


            }
        }

    }
}
