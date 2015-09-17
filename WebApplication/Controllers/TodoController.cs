using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            var db = new DataContext();
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            var db = new DataContext();

            db.Tasks.Add(task);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Int32 Id)
        {
            var db = new DataContext();
            var task = db.Tasks.Single(t => t.Id == Id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            var db = new DataContext();
            var taskOld = db.Tasks.Single(t => t.Id == task.Id);

            taskOld.Name = task.Name;
            taskOld.Done = task.Done;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(Int32 Id)
        {
            var db = new DataContext();
            var task = db.Tasks.Single(t => t.Id == Id);
            db.Tasks.Remove(task);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}