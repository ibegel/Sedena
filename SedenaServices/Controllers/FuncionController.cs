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
    public class FuncionController : ApiController
    {
            [HttpGet]
            // localhost/api/Doctor
            public IEnumerable<FuncionCLS> listaFuncion()
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    IEnumerable<FuncionCLS> listarFuncion = (from fun in bd.Funcion
                                                          select new FuncionCLS
                                                          {
                                                             
                                                             id_Funcion=fun.Id_Funcion,
                                                             funcion=fun.Funcion1,
                                                             id_Agente=(int)fun.Id_Agente,
                                                             id_Sesion=(int)fun.Id_Sesion

                                                          }).ToList();
                    return listarFuncion;
                }
            }

            [HttpPut]
            public int eliminarFuncion(int id_Funcion)
            {
                int respuesta = 0;
                try
                {
                    using (DBSedenaDataContext bd = new DBSedenaDataContext())
                    {
                        Funcion oFuncion = bd.Funcion.Where(p => p.Id_Funcion == id_Funcion).First();
                        oFuncion.Funcion1 = "Inhabilitado";
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
            public int agregarFun(Funcion oFuncion)
                {
               
                    int respuesta = 0;
                    try
                    {
                        using (DBSedenaDataContext bd = new DBSedenaDataContext())
                        {
                            if (oFuncion.Id_Funcion == 0)
                            {
                                IEnumerable<FuncionCLS> listaFuncion = (from funci in bd.Funcion
                                                                            where funci.Funcion1 != "Inhabilitado"
                                                                            select new FuncionCLS
                                                                            {
                                                                                id_Funcion = funci.Id_Funcion
                                                                            }).ToList();
                                oFuncion.Id_Funcion = listaFuncion.Count() + 1;
                                bd.Funcion.InsertOnSubmit(oFuncion);
                                bd.SubmitChanges();
                                respuesta = 1;
                            }
                            else
                            {
                                Funcion aux = bd.Funcion.Where(p => p.Id_Funcion == oFuncion.Id_Funcion).First();
                                aux.Id_Funcion = oFuncion.Id_Funcion;
                                aux.Funcion1 = oFuncion.Funcion1;
                                aux.Id_Agente = oFuncion.Id_Agente;
                                aux.Id_Sesion = oFuncion.Id_Sesion;
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
            public FuncionCLS recuperarFuncion(int id_Funcion)
            {
                using (DBSedenaDataContext bd = new DBSedenaDataContext())
                {
                    FuncionCLS oDoctor = bd.Funcion.Where(p => p.Id_Funcion == id_Funcion)
                        .Select(p => new FuncionCLS
                        {
                            id_Funcion=p.Id_Funcion,
                            funcion=p.Funcion1,
                            id_Agente=(int)p.Id_Agente,
                            id_Sesion=(int)p.Id_Sesion
                        }
                        ).First();

                    return oDoctor;


                }
            }
        }
    }

