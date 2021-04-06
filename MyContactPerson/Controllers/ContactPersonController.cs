using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyContactPerson.Models;

namespace MyContactPerson.Controllers
{
    public class ContactPersonController : Controller
    {
        private DBkuEntities db = new DBkuEntities();

        // GET: /ContactPerson/
        public ActionResult Index()
        {
            return View(db.ContactKUs.ToList());
        }

        // GET: /ContactPerson/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactKU contactku = db.ContactKUs.Find(id);
            if (contactku == null)
            {
                return HttpNotFound();
            }
            return View(contactku);
        }

        // GET: /ContactPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NameCP,PhoneCP,EmailCP,CompanyCP,CountryCP,ZipCodeCP,StatetCP,CityCP")] ContactKU contactku)
        {
            if (ModelState.IsValid)
            {
                db.ContactKUs.Add(contactku);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactku);
        }

        // GET: /ContactPerson/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactKU contactku = db.ContactKUs.Find(id);
            if (contactku == null)
            {
                return HttpNotFound();
            }
            return View(contactku);
        }

        // POST: /ContactPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NameCP,PhoneCP,EmailCP,CompanyCP,CountryCP,ZipCodeCP,StatetCP,CityCP")] ContactKU contactku)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactku).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactku);
        }

        // GET: /ContactPerson/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactKU contactku = db.ContactKUs.Find(id);
            if (contactku == null)
            {
                return HttpNotFound();
            }
            return View(contactku);
        }

        // POST: /ContactPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ContactKU contactku = db.ContactKUs.Find(id);
            db.ContactKUs.Remove(contactku);
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
