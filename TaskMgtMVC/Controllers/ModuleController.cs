using Core;
using DataAccessInMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMgtMVC.Controllers
{
    public class ModuleController : Controller
    {
        DynRepository<Module> moduleObj;

        public ModuleController()
        {
            moduleObj = new DynRepository<Module>();
        }

        // GET: Module
        public ActionResult Index()
        {
            return View(moduleObj.GetAllData());
        }

        //create blank page for adding records.
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// Adding Module.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public ActionResult Add(Module module)
        {
            if (ModelState.IsValid)
            {
                moduleObj.Add(module);
                moduleObj.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Edit page with displaying current selected record details.
        public ActionResult Edit(string Id)
        {
            if (ModelState.IsValid)
            {
                Module module = moduleObj.GetDetail(Id);
                return View(module);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        //Edit Submit button clicked==>Now record needs to be updated.
        public ActionResult Edit(Module module, string Id)
        {
            if (ModelState.IsValid)
            {
                Module moduleOld = moduleObj.GetDetail(Id);
                moduleOld.Name = module.Name;
                moduleObj.Commit();
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }

        //Delete page with displaying current selected record details.
        public ActionResult Delete(string Id)
        {
            if (ModelState.IsValid)
            {
                Module module = moduleObj.GetDetail(Id);
                return View(module);
            }
            else
            {
                return View();
            }
        }

        [ActionName("Delete")]
        [HttpPost]
        //Delete Delete button clicked==>Now record needs to be Deleted.
        public ActionResult ConfirmDelete(string Id)
        {
            if (ModelState.IsValid)
            {
                moduleObj.Delete(Id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}