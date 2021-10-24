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
    //Se encarga de admiinistar el flujo de entrada y salida de datos que existen en la tabla de Encargado y la tabla agente
    //Esta realiza la funcion de busqueda dentro de la tabla Agente y de la tabla Encargado ya que como se propuso en la base de datos un Encargado es un Agente con privilegios
    //Esta se ve complementada con las condiciones proporcionadas por el usuario para dar un mejor control en los mismos
    //
    //
    public class EncargadoController : ApiController
    {
        //Este controlador reune los campos de dos tablas en este caso la tabla Agente y la tabla Encargado
        //Los reune en una lista para despues convertirlos en json y retornalos 
        [HttpGet]
        public EncargadosCLS listaEncargado()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<EncargadoCLS> listarEncargado = (from encar in bd.Encargado
                                                      join usu in bd.Agente
                                                      on encar.Id_Agente equals usu.Id_Agente
                                                      select new EncargadoCLS
                                                      {
                                                          matricula = usu.Matricula,
                                                          grado = usu.Grado,
                                                          nombre = usu.Nombre,
                                                          distintivo = usu.Distintivo,
                                                          arma = usu.Arma,
                                                          idAgente = usu.Id_Agente,
                                                          usuario=encar.Usuario,
                                                          password=encar.Pass
                                                      }).ToList();
                EncargadosCLS encargados = new EncargadosCLS();
                encargados.encargados = listarEncargado.ToArray();
                return encargados;
            }
        }
        
        //Campo de borrado en el controlador encargado 
        //Se proporciona el id de un Encargado y en caso de encontrarlo lo borra lo que significa que ya no tendra los privilegios que vienen dentro de este campo
        //En caso de no encontrarlo envia un 0 el cual significara que no lo borro
        [HttpDelete]
        public int eliminarEncargado(int id_Encargado)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Encargado oEncargado = bd.Encargado.Where(p => p.Id_Encargado == id_Encargado).First();
                    bd.Encargado.DeleteOnSubmit(oEncargado);
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

        //recupera los datos ingresados por el usuarios y los guarda dentro de un Json para que sea mejor su manipulacion
        //Recupera de la base de datos todos los agentes existentes al igual que los encargados 
        //Y despues buscara que los campos no se repitan para que los encargados no tengas mismos nombre de usuario o matricula 
        //Primero busca que la matricula no este repetida para evitar que se repita los datos
        //Si la matricula esta correcta entonces se comprueba que el agente no sea un encargado ya 
        //Si es un encargado ya entonces habilitara la opcion de actualizar los datos 
        //Si la matricula es correcta pero el agente no es un encargado entonces el Agente sera ascendido a Encargado 
        [HttpPost]
        public string agregarEncargado(EntradaCLS data)
        {
            JObject json = JObject.Parse(data.data);
            int existe = 0;
            string respuesta = "";
            int existeen = 0;
            List<AgenteCLS> listarAgente = new List<AgenteCLS>() { };
            List<EncargadoCLS> listaver = new List<EncargadoCLS> { };

            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                 listarAgente = (from usu in bd.Agente
                                                select new AgenteCLS
                                                {
                                                    idAgente = usu.Id_Agente,
                                                    matricula=usu.Matricula
                                                }).ToList();
                foreach (var a in listarAgente)
                {
                    if (a.idAgente.Equals((int)json["idAgente"]))
                    {
                        existe = 1;
                        break;
                    }
                }

                 listaver = (from encar in bd.Encargado
                                                      join usua in bd.Agente
                                                      on encar.Id_Agente equals usua.Id_Agente
                                                      select new EncargadoCLS
                                                      {
                                                          idAgente = (int)encar.Id_Agente,
                                                          usuario=(string)encar.Usuario,


                                                      }).ToList();

               
            }
            int bandera = 0;

            foreach (var x in listarAgente)
            {
                if (x.matricula.Equals((string)json["matricula"]))
                {
                    if (x.idAgente.Equals((int)json["idAgente"]))
                    {
                        bandera = 0;
                    }
                    else
                    {
                        bandera = 1;
                        break;
                    }
                }
            }
            
                if (bandera == 0)
                {
                    if (existe == 1)
                    {

                        try
                        {
                            using (DBSedenaDataContext bd = new DBSedenaDataContext())
                            {
                                Encargado nuevo = new Encargado();
                            ///crear encargado
                                if ((int)json["idEncargado"] == 0)
                                {
                                List<EncargadoCLS> listaEncargado = (from encarga in bd.Encargado
                                                                     select new EncargadoCLS
                                                                     {
                                                                         idEncargado = encarga.Id_Encargado,
                                                                         idAgente=(int)encarga.Id_Agente
                                                                     }).ToList();

                                int idDuplicado = 0;
                                foreach (var x in listaEncargado)
                                {
                                    if (x.idAgente == (int)json["idAgente"])
                                    {
                                        idDuplicado = 1;
                                        break;
                                    }
                                }

                                if (idDuplicado == 0)
                                {

                                    if (listaEncargado.Last().idEncargado.Equals(listaEncargado.Count() + 1))
                                    {
                                        nuevo.Id_Encargado = listaEncargado.Count() + 2;
                                    }
                                    else
                                    {
                                        nuevo.Id_Encargado = listaEncargado.Count() + 1;
                                    }
                                    nuevo.Usuario = (string)json["usuario"];
                                    nuevo.Pass = (string)json["password"];
                                    nuevo.Id_Agente = (int)json["idAgente"];




                                    Agente aux1 = bd.Agente.Where(p => p.Id_Agente == (int)json["idAgente"]).First();
                                    aux1.Id_Agente = (int)json["idAgente"];
                                    aux1.Matricula = (string)json["matricula"];
                                    aux1.Grado = (string)json["grado"];
                                    aux1.Nombre = (string)json["nombre"];
                                    aux1.Distintivo = (string)json["distintivo"];
                                    aux1.Arma = (string)json["arma"];
                                    aux1.Existencia = 1;
                                    bd.Encargado.InsertOnSubmit(nuevo);
                                    bd.SubmitChanges();
                                    respuesta += "Agente Actualizado";
                                    respuesta += "Encargado Insertado";
                                    return respuesta;
                                }
                                else 
                                {
                                    respuesta = "El agente ya es encargado";
                                }

                                }
                                //Borrar Encargado
                                else
                                {
                                    Agente aux1 = bd.Agente.Where(p => p.Matricula == (string)json["matricula"]).First();
                                    aux1.Id_Agente = (int)json["idAgente"];
                                    aux1.Matricula = (string)json["matricula"];
                                    aux1.Grado = (string)json["grado"];
                                    aux1.Nombre = (string)json["nombre"];
                                    aux1.Distintivo = (string)json["distintivo"];
                                    aux1.Arma = (string)json["arma"];
                                    aux1.Existencia = 1;
                                    bd.SubmitChanges();
                                    respuesta += "Agente Actualizado";
                                    Encargado aux = bd.Encargado.Where(p => p.Id_Encargado == (int)json["idEncargado"]).First();
                                    aux.Id_Encargado = (int)json["idEncargado"];
                                    aux.Usuario = (string)json["usuario"];
                                    aux.Pass = (string)json["password"];
                                    aux.Id_Agente = (int)json["idAgente"];
                                    bd.SubmitChanges();
                                    respuesta += "Encargado Actualizado";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            respuesta ="soy un error"+ ex.Message;
                        }
                        return respuesta;
                    }
                    else
                    {
                        return respuesta = "No existe el Agente";
                    }

                }
                else
                {
                    return respuesta = "Matricula Erronea o Duplicada";
                }
           
        }

        //Controlador que retorna un encargado especifico que cumpla la caracteristicas 
        //Se solicita el identificador del Encargado
        //hacemos una peticion de los campos en la tabla Agente y a la tabla encargado
        //Generemos una lista con la union de los campos con mismas datos
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios

        [HttpGet]
        public EncargadoCLS recuperarEncargado(int id_Encargado)
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                EncargadoCLS oEncargado = (from encar in bd.Encargado
                                           join usu in bd.Agente
                                           on encar.Id_Agente equals usu.Id_Agente
                                           where encar.Id_Encargado == id_Encargado
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
                                           }).First();

                return oEncargado;
            }
        }

        //Controlador que retorna un encargado especifico que cumpla la caracteristicas 
        //Se solicita el nombre del Encargado
        //hacemos una peticion de los campos en la tabla Agente y a la tabla encargado
        //Generemos una lista con la union de los campos con mismas datos
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios
        [HttpGet]
        public EncargadoCLS recuperarNombre(string nombre)
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
                    if (a.nombre.ToLower().Equals(nombre.ToLower()))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

        //Controlador que retorna un encargado especifico que cumpla la caracteristicas 
        //Se solicita el distintivo del Encargado
        //hacemos una peticion de los campos en la tabla Agente y a la tabla encargado
        //Generemos una lista con la union de los campos con mismas datos
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios
        [HttpGet]
        public EncargadoCLS recuperarDistintivo(string distintivo)
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
                    if (a.distintivo.ToLower().Equals(distintivo.ToLower()))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }


        //Controlador que retorna un encargado especifico que cumpla la caracteristicas 
        //Se solicita la matricula del Encargado
        //hacemos una peticion de los campos en la tabla Agente y a la tabla encargado
        //Generemos una lista con la union de los campos con mismas datos
        //Si alguno de ellos cumple la condicion entonces lo recuperamos 
        //Si nunguno cumple la condicion regresamos un Agente con los campos vacios
        [HttpGet]
        public EncargadoCLS recuperarMatricula(string matricula)
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
                    if (a.matricula.Equals(matricula))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

        
        

    }
}
