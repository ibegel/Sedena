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
    //Controlador creado para poder verificar los datos de inicio de sesion de una manera mas sencilla 
    public class LoginController : ApiController
    {
        //Se solicita los campos user y password al usuario 
        //Se recupera una lista con todos los datos de la tabla Encargado
        //Comparamos los datos que ingresamos con los existente y conforme a esas comparaciones regresamos diversos campos
        //Devuelve -1 si el usuario no existe
        //Devuelve 0 si el usuario es correcto pero la contraseña no es correcta
        //Devuelve 1 si ambos campos son correctos
        [HttpGet]
        public int logeo(string user, string password)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<EncargadoCLS> listarEncargado = (from encar in bd.Encargado
                                                      join usu in bd.Agente
                                                      on encar.Id_Agente equals usu.Id_Agente
                                                      select new EncargadoCLS
                                                      {
                                                          idEncargado = encar.Id_Encargado,
                                                          matricula = usu.Matricula,
                                                          grado = usu.Grado,
                                                          nombre = usu.Nombre,
                                                          distintivo = usu.Distintivo,
                                                          arma = usu.Arma,
                                                          existencia = (int)usu.Existencia,
                                                          usuario = encar.Usuario,
                                                          password = encar.Pass,

                                                          idAgente = usu.Id_Agente
                                                      }).ToList();
                EncargadoCLS aux = new EncargadoCLS();
                foreach (var a in listarEncargado)
                {
                    if (a.usuario.Equals(user))
                    {
                        aux = a;
                        break;
                    }
                }
                if (aux.idEncargado == 0)
                {
                    return -1;
                }
                else
                {
                    if (aux.password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
        }

    }
}
