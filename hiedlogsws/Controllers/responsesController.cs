using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using hiedlogsws.Models;

namespace hiedlogsws.Controllers
{
    [EnableCors("*", "*", "*")]
    public class responsesController : Controller
    {
        private HIEDEntities db = new HIEDEntities();

        // GET: responses
        public ActionResult Index()
        {
            return View(db.response.ToList());
        }

        // GET: responses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            response response = db.response.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // GET: responses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: responses/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [EnableCors("*", "*", "*")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "responseStatus,responseText,responseTime,userId,id")] response response)
        {
            if (ModelState.IsValid)
            {
                response.id = Guid.NewGuid();
                db.response.Add(response);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(response);
        }

        // GET: responses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            response response = db.response.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: responses/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [EnableCors("*", "*", "*")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "responseStatus,responseText,responseTime,userId,id")] response response)
        {
            if (ModelState.IsValid)
            {
                db.Entry(response).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(response);
        }

        // GET: responses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            response response = db.response.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // POST: responses/Delete/5
        [EnableCors("*", "*", "*")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            response response = db.response.Find(id);
            db.response.Remove(response);
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
