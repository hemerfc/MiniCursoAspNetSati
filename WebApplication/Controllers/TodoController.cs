using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.SignalrHub;

namespace WebApplication.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            var db = new DataContext();
            var tasks = db.Tasks.OrderBy(x => x.Id).ToList();
            return View(tasks);
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            var db = new DataContext();

            db.Tasks.Add(task);
            db.SaveChanges();

            GlobalHost.ConnectionManager.GetHubContext<TasksHub>().Clients.All.newtask(task);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Task task)
        {
            var db = new DataContext();
            var taskOld = db.Tasks.Single(t => t.Id == task.Id);

            taskOld.Name = task.Name;
            taskOld.Done = task.Done;

            db.SaveChanges();

            GlobalHost.ConnectionManager.GetHubContext<TasksHub>().Clients.All.newtask(task);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Int32 Id)
        {
            var db = new DataContext();
            var task = db.Tasks.Single(t => t.Id == Id);
            db.Tasks.Remove(task);
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult ChangeState(int Id)
        {
            var db = new DataContext();
            var task = db.Tasks.Single(t => t.Id == Id);
            task.Done = !task.Done;
            db.SaveChanges();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}