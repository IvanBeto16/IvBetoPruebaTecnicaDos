using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Liga
    {
        public static ML.Result Add(ML.Liga liga)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.LigaAdd(liga.NombreLiga,liga.Pais,liga.Confederacion.IdConfederacion,filasInsertadas);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Liga liga)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.LigaUpdate(liga.IdLiga,liga.NombreLiga,liga.Pais,liga.Confederacion.IdConfederacion,
                        filasActualizadas);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int idLiga)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.LigaDelete(idLiga,filasEliminadas);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllLigas()
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
            {
                var query = context.LigaGetAll();
                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach(var item in query)
                    {
                        ML.Liga liga = new ML.Liga();
                        liga.Confederacion = new ML.Confederacion();
                        liga.IdLiga = item.IdLiga;
                        liga.NombreLiga = item.NombreLiga;
                        liga.Pais = item.Pais;
                        liga.Confederacion.IdConfederacion = item.IdConfederacion;
                        liga.Confederacion.Nombre = item.Nombre;

                        result.Objects.Add(liga);
                        result.Correct = true;
                    }
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron ligas registradas";
                }
            }
            return result;
        }


        public static ML.Result GetById(int idLiga)
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
            {
                var query = context.LigaGetById(idLiga);
                if(query != null)
                {
                    result.Object = new object();
                    foreach(var item in query)
                    {
                        ML.Liga liga = new ML.Liga();
                        liga.Confederacion = new ML.Confederacion();
                        liga.IdLiga = item.IdLiga;
                        liga.NombreLiga = item.NombreLiga;
                        liga.Pais = item.Pais;
                        liga.Confederacion.IdConfederacion = item.IdConfederacion;
                        liga.Confederacion.Nombre = item.Nombre;

                        result.Object = liga;
                        result.Correct = true;
                    }
                }
                else
                {
                    result.Correct = false;
                }
            }
            return result;
        }
    }
}
