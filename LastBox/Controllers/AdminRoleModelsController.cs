using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LastBox.Models;

namespace LastBox.Controllers
{
    public class AdminRoleModelsController : Controller
    {
        private RegisteredUserDbContext db = new RegisteredUserDbContext();

        // GET: AdminRoleModels
        public ActionResult Index()
        {
            return View(db.AdminRoleModels.ToList());
        }

        // GET: AdminRoleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRoleModel adminRoleModel = db.AdminRoleModels.Find(id);
            if (adminRoleModel == null)
            {
                return HttpNotFound();
            }
            return View(adminRoleModel);
        }

        // GET: AdminRoleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRoleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] AdminRoleModel adminRoleModel)
        {
            if (ModelState.IsValid)
            {
                db.AdminRoleModels.Add(adminRoleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminRoleModel);
        }

        // GET: AdminRoleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRoleModel adminRoleModel = db.AdminRoleModels.Find(id);
            if (adminRoleModel == null)
            {
                return HttpNotFound();
            }
            return View(adminRoleModel);
        }

        // POST: AdminRoleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AdminRoleModel adminRoleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminRoleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminRoleModel);
        }

        // GET: AdminRoleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRoleModel adminRoleModel = db.AdminRoleModels.Find(id);
            if (adminRoleModel == null)
            {
                return HttpNotFound();
            }
            return View(adminRoleModel);
        }

        // POST: AdminRoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminRoleModel adminRoleModel = db.AdminRoleModels.Find(id);
            db.AdminRoleModels.Remove(adminRoleModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
