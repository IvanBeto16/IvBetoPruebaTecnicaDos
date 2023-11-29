using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Confederacion
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DL.IvBetoPruebaTecnicaDosEntities context = new DL.IvBetoPruebaTecnicaDosEntities())
            {
                var query = context.ConfedGetAll();
                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach(var item in query)
                    {
                        ML.Confederacion confederacion = new ML.Confederacion();
                        confederacion.IdConfederacion = item.IdConfederacion;
                        confederacion.Nombre = item.Nombre;

                        result.Objects.Add(confederacion);
                        result.Correct = true;
                    }
                }
                else
                {
                    result.Correct= false;
                    result.ErrorMessage = "No se encontraron registros en la tabla";
                }
                return result;
            }
        }
    }
}
