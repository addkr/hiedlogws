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
    public class socialMediasController : Controller
    {
        private HIEDEntities db = new HIEDEntities();

        // GET: socialMedias
        public ActionResult Index()
        {
            return View(db.socialMedia.ToList());
        }

        // GET: socialMedias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socialMedia socialMedia = db.socialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // GET: socialMedias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: socialMedias/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [EnableCors("*", "*", "*")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,SMname,id")] socialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                socialMedia.id = Guid.NewGuid();
                db.socialMedia.Add(socialMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialMedia);
        }

        // GET: socialMedias/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socialMedia socialMedia = db.socialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: socialMedias/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [EnableCors("*", "*", "*")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "userId,SMname,id")] socialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }

        // GET: socialMedias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socialMedia socialMedia = db.socialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: socialMedias/Delete/5
        [EnableCors("*", "*", "*")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            socialMedia socialMedia = db.socialMedia.Find(id);
            db.socialMedia.Remove(socialMedia);
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
