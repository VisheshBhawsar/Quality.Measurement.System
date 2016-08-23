using Models;
using Models.DAL;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrapperExtensions;

namespace Quality.Measurement.System.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repository;

        public HomeController()
        {
            this._repository = new Repository(new ModelStateWrapper(this.ModelState));
        }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public JsonResult GetTodoList()
        {
            var tl = this._repository.Entity<List>().OrderBy(o => o.Id).ToList();

            return Json(tl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserName()
        {
            var tl = this._repository.Entity<List>().OrderBy(o => o.Id).ToList();

            return Json(tl, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddList(List list)
        {
            this._repository.Insert(list);
            this._repository.Save();

            return Json(new JSONReturnVM<List>(list, this.ModelState));
        }

        [HttpPost]
        public JsonResult UpdateList(List list)
        {
            this._repository.Update(list);
            this._repository.Save();

            return Json(new JSONReturnVM<List>(list, this.ModelState));
        }

        [HttpPost]
        public JsonResult DeleteList(List list)
        {
            this._repository.Delete<List>(list.Id);
            this._repository.Save();

            return Json(new JSONReturnVM<List>(list, this.ModelState));
        }

        [HttpPost]
        public JsonResult AddTask(Task task)
        {
            this._repository.Insert(task);
            this._repository.Save();

            return Json(new JSONReturnVM<Task>(task, this.ModelState));
        }

        [HttpPost]
        public JsonResult UpdateTask(Task task)
        {
            this._repository.Update(task);
            this._repository.Save();

            return Json(new JSONReturnVM<Task>(task, this.ModelState));
        }

        [HttpPost]
        public JsonResult DeleteTask(Task task)
        {
            this._repository.Delete<Task>(task.Id);
            this._repository.Save();

            return Json(new JSONReturnVM<Task>(task, this.ModelState));
        }
    }
}