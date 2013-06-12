using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcConventions.ViewModels;

namespace MvcConventions.Controllers
{
    public class ModelBindingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleValue(int id = 0)
        {
            ViewBag.Number = ConvertNumberToWords(id);
            
            return View(id);
        }
        
        #region Simple Object Model binding
        
        [HttpGet]
        public ActionResult SimpleObject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SimpleObject(ModelBindingSimpleVM vm)
        {
            TempData["simple"] = vm;

            return RedirectToAction("SimpleObjectResult");
        }

        [HttpGet]
        public ActionResult SimpleObjectResult()
        {
            var vm = TempData["simple"] as ModelBindingSimpleVM;
            return View(vm);
        } 

        #endregion

        #region Private

        private string ConvertNumberToWords(int id)
        {
            if (id > 10)
            {
                return "";
            }

            string[] numbersToLetters = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };

            return numbersToLetters[id];
        }

        #endregion
    }
}
