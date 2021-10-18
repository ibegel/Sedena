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
        public AgentesCLS listaEncargado()
        {
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<AgenteCLS> listarEncargado = (from encar in bd.Encargado
                                                      join usu in bd.Agente
                                                      on encar.Id_Agente equals usu.Id_Agente
                                                      select new AgenteCLS
                                                      {
                                                          matricula = usu.Matricula,
                                                          grado = usu.Grado,
                                                          nombre = usu.Nombre,
                                                          distintivo = usu.Distintivo,
                                                          arma = usu.Arma,
                                                          idAgente = usu.Id_Agente
                                                      }).ToList();
                AgentesCLS encargados = new AgentesCLS();
                encargados.agentes = listarEncargado.ToArray();
                return encargados;
            }
        }

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


        [HttpPut]
        public int inhabilitarEncargado(int id_Encargado)
        {
            int respuesta = 0;
            try
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    Encargado oEncargado = bd.Encargado.Where(p => p.Id_Encargado == id_Encargado).First();
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
        public int agregarEncargado(Encargado oEncargado)
        {
            int existe = 0;
            int respuesta = 0;
            using (DBSedenaDataContext bd = new DBSedenaDataContext())
            {
                List<AgenteCLS> listarAgente = (from usu in bd.Agente
                                                select new AgenteCLS
                                                {
                                                    idAgente = usu.Id_Agente
                                                }).ToList();
                foreach (var a in listarAgente)
                {
                    if (a.idAgente.Equals(oEncargado.Id_Agente))
                    {
                        existe = 1;
                        break;
                    }
                }
            }

            if (existe == 1)
            {
                
                try
                {
                    using (DBSedenaDataContext bd = new DBSedenaDataContext())
                    {
                        if (oEncargado.Id_Encargado == 0)
                        {
                            List<EncargadoCLS> listaEncargado = (from encarga in bd.Encargado
                                                                 where encarga.Tipo_Encargado != "Inhabilitado"
                                                                 select new EncargadoCLS
                                                                 {
                                                                     idEncargado = encarga.Id_Encargado
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
                            aux.Id_Agente = oEncargado.Id_Agente;
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
            else
            {
                return respuesta = -1;
            }
        }

        // localhost/api/Doctor/?iidDoctor=
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
                                               tipoEncargado = encar.Tipo_Encargado,
                                               pass = encar.Pass,

                                               idAgente = usu.Id_Agente
                                           }).First();

                return oEncargado;
            }
        }

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
                                                          tipoEncargado = encar.Tipo_Encargado,
                                                          pass = encar.Pass,

                                                          idAgente = usu.Id_Agente
                                                      }).ToList();
                EncargadoCLS aux = new EncargadoCLS();
                foreach (var a in listarEncargado)
                {
                    if (a.nombre.Equals(nombre))
                    {
                        aux = a;
                        break;
                    }
                }
                return aux;
            }
        }

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
                                                          tipoEncargado = encar.Tipo_Encargado,
                                                          pass = encar.Pass,

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
