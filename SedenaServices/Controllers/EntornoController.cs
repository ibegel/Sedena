using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SedenaServices.Models.Clases;
using SedenaServices.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace SedenaServices.Controllers
{
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    //Se encarga de administrar los datos guardados por el usuario basados en los entornos que fueron creados 
    //Los campos aqui guardados tienen un entorno que puede ser recuperado en unity a fin de volver a generarlo y tener variadas opciones al momento de entrenar
    public class EntornoController : ApiController
    {
        //Recupera todos entornos que fueron guarddosen la base de datos 
        //los deposita en una lista la cual despues es convertida en un arreglo 
        //finalmente los envia como respuesta a la peticion, en un formato tipo Json
        [HttpGet]
        public EntornosCLS listaEntorno()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                List<EntornoCLS> listaEnt = (from ento in bd.Entorno
                                             select new EntornoCLS
                                             {
                                                 name = ento.Nombre,
                                                 escenario = ento.Escenario,
                                                 descripcion = ento.Descripcion,
                                                 jsonOdin = ento.JsonOdin
                                             }).ToList();
                ent.entornos = listaEnt.ToArray();
                return ent;

            }
        }
        //Campo de control de flujo de entra de datos en la tabla Entorno
        //Obtiene los datos y los convierte en un objeto del tipo json
        //Recupera todos entornos que fueron guardados en la base de datos con el fin de buscar si el nombre del que sera agregado ya existe
        //Si no existe entonces lo podemos agregar sin mayor dificultad, pero si existe entonces mandamos un mensaje de que ya existe el campo a evaluar
        [HttpPost]
        public string agregarEntorno(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            string respuesta = "";
            int existe = 0;
            EntornosCLS lista_nombre = new EntornosCLS();
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                lista_nombre.entornos = (from ento in bd.Entorno
                                             select new EntornoCLS
                                             {
                                                 name = ento.Nombre,
                                             }).ToArray();
            }

            foreach (var x in lista_nombre.entornos)
            {
                if (x.name == (string)json["name"])
                {
                    existe = 1;
                    break;
                }
            }
            if (existe == 0)
            {
                try
                {
                    using (DBSedenaDataContext bd = new DBSedenaDataContext())
                    {
                        Entorno nuevo = new Entorno() { };

                        nuevo.Nombre = (string)json["name"];
                        nuevo.Escenario = (string)json["escenario"];
                        nuevo.Descripcion = (string)json["descripcion"];
                        nuevo.JsonOdin = (string)json["jsonOdin"];
                        bd.Entorno.InsertOnSubmit(nuevo);
                        bd.SubmitChanges();
                    }
                    respuesta = "Ingresado";                
                }
                catch (Exception ex)
                {
                    respuesta = ex.Message;
                }
            }
            else 
            {
                respuesta = "El nombre ya esta ocupado";
            }
                return respuesta;
            }

        //Controlador que retorna un entorno especifico que cumpla la caracteristicas 
        //Se solicita el name del Entorno
        //hacemos una peticion de los campos en la tabla Entorno con la condicion de retornar solo el valor donde el campo name coincida con el ingresao
        //Recuperamos los datos y los ingresamos 
        [HttpGet]
        public EntornoCLS listaEntorno(string name)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EntornosCLS ent = new EntornosCLS();
                EntornoCLS seleccion = (from ento in bd.Entorno
                                        where ento.Nombre == name
                                        select new EntornoCLS
                                        {
                                            name = ento.Nombre,
                                            escenario = ento.Escenario,
                                            descripcion = ento.Descripcion,
                                            jsonOdin = ento.JsonOdin
                                        }).First();
                return seleccion;

            }
        }


    }
    

}
