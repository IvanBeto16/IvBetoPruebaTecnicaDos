using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult AllEquipos()
        {
            ML.Equipo equipo = new ML.Equipo();
            equipo.Equipos = new List<object>();
            ML.Result result = BL.Equipo.GetAll();
            if (result.Correct)
            {
                equipo.Equipos = result.Objects;
            }
            return View(equipo);
        }

        [HttpGet]
        public ActionResult FormEquipo(int idEquipo)
        {
            ML.Equipo equipo = new ML.Equipo();
            equipo.Liga = new ML.Liga();
            equipo.Liga.Ligas = new List<object>();
            ML.Result resultLiga = BL.Liga.GetAllLigas();
            if(idEquipo == 0)
            {
                equipo.Liga.Ligas = resultLiga.Objects;
            }
            else
            {
                ML.Result result = BL.Equipo.GetById(idEquipo);
                if(result.Correct)
                {
                    equipo = (ML.Equipo)result.Object;
                    equipo.Liga.Ligas = resultLiga.Objects;
                }
            }
            return View(equipo);
        }

        [HttpPost]
        public ActionResult FormEquipo(ML.Equipo equipo)
        {
            ML.Result resultLiga = BL.Liga.GetAllLigas();
            if(equipo.IdEquipo == 0)
            {
                ML.Result result = BL.Equipo.Add(equipo);
                if (result.Correct)
                {
                    return RedirectToAction("AllEquipos", "Equipo");
                }
                else
                {
                    equipo.Liga.Ligas = resultLiga.Objects;
                    return View(equipo);
                }
            }
            else
            {
                ML.Result result = BL.Equipo.Update(equipo);
                if(result.Correct)
                {
                    return RedirectToAction("AllEquipos", "Equipo");
                }
                else
                {
                    equipo.Liga.Ligas = resultLiga.Objects;
                    return View(equipo);
                }
            }
        }
    }
}