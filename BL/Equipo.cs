using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Equipo
    {
        public static ML.Result Add(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.EquipoAdd(equipo.NombreEquipo, equipo.AnioFundacion, equipo.CiudadSede, equipo.Estadio,
                        equipo.TitulosNacionales, equipo.TitulosInternacionales, equipo.Liga.IdLiga, filasInsertadas);

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

        

        public static ML.Result Update(ML.Equipo equipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.EquipoUpdate(equipo.IdEquipo, equipo.NombreEquipo, equipo.AnioFundacion, equipo.CiudadSede,
                        equipo.Estadio, equipo.TitulosNacionales, equipo.TitulosInternacionales, equipo.Liga.IdLiga, filasActualizadas);

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


        public static ML.Result Delete(int idEquipo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.EquipoDelete(idEquipo, filasEliminadas);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
            {
                var query = context.EquipoGetAll();
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Equipo equipo = new ML.Equipo();
                        equipo.Liga = new ML.Liga();
                        equipo.IdEquipo = item.IdEquipo;
                        equipo.NombreEquipo = item.NombreEquipo;
                        equipo.AnioFundacion = item.AnioFundacion.Value;
                        equipo.CiudadSede = item.CiudadSede;
                        equipo.Estadio = item.Estadio;
                        equipo.TitulosNacionales = item.TitulosNacionales.Value;
                        equipo.TitulosInternacionales = item.TitulosInternacionales.Value;
                        equipo.Liga.IdLiga = item.IdLiga;
                        equipo.Liga.NombreLiga = item.NombreLiga;

                        result.Objects.Add(equipo);
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


        public static ML.Result GetById(int idEquipo)
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
            {
                var query = context.EquipoGetById(idEquipo);
                if (query != null)
                {
                    result.Object = new object();
                    foreach (var item in query)
                    {
                        ML.Equipo equipo = new ML.Equipo();
                        equipo.Liga = new ML.Liga();
                        equipo.IdEquipo = item.IdEquipo;
                        equipo.NombreEquipo = item.NombreEquipo;
                        equipo.AnioFundacion = item.AnioFundacion.Value;
                        equipo.CiudadSede = item.CiudadSede;
                        equipo.Estadio = item.Estadio;
                        equipo.TitulosNacionales = item.TitulosNacionales.Value;
                        equipo.TitulosInternacionales = item.TitulosInternacionales.Value;
                        equipo.Liga.IdLiga = item.IdLiga;
                        equipo.Liga.NombreLiga = item.NombreLiga;

                        result.Object = equipo;
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
