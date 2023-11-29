using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LigaController : Controller
    {
        // GET: Liga
        [HttpGet]
        public ActionResult GetAllLigas()
        {
            ML.Result result = BL.Liga.GetAllLigas();
            ML.Liga liga  = new ML.Liga();
            liga.Ligas = new List<object>();
            if (result.Correct)
            {
                liga.Ligas = result.Objects;
            }
            return View(liga);
        }

        [HttpGet]
        public ActionResult FormLiga(int idLiga)
        {
            ML.Liga liga = new ML.Liga();
            liga.Confederacion = new ML.Confederacion();
            ML.Result resultConfed = BL.Confederacion.GetAll();
            liga.Confederacion.Confederaciones = new List<object>();
            liga.IdLiga = idLiga;
            if(idLiga != 0)
            {
                ML.Result result = BL.Liga.GetById(idLiga);
                if(result.Correct)
                {
                    liga = (ML.Liga)result.Object;
                    liga.Confederacion.Confederaciones = resultConfed.Objects;
                }
            }
            else
            {
                liga.Confederacion.Confederaciones = resultConfed.Objects;
            }
            return View(liga);
        }

        [HttpPost]
        public ActionResult FormLiga(ML.Liga liga)
        {
            ML.Result resultConfed = BL.Confederacion.GetAll();
            if(liga.IdLiga == 0)
            {
                ML.Result result = BL.Liga.Add(liga);
                if (result.Correct)
                {
                    return RedirectToAction("GetAllLigas", "Liga");
                }
                else
                {
                    liga.Confederacion.Confederaciones = resultConfed.Objects;
                    return View(liga);
                }

            }
            else
            {
                ML.Result result = BL.Liga.Update(liga);
                if (result.Correct)
                {
                    return RedirectToAction("GetAllLigas", "Liga");
                }
                else
                {
                    liga.Confederacion.Confederaciones = resultConfed.Objects;
                    return View(liga);
                }
            }
        }


        public ActionResult Delete(int idLiga)
        {
            ML.Result result = BL.Liga.Delete(idLiga);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el elemento";
            }
            else
            {
                ViewBag.Message = "Ha ocurrido un error al momento de eliminar el elemento, " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}