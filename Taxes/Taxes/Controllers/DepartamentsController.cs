using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxes.Models;

namespace Taxes.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartamentsController : Controller
    {
        private TaxesContext db = new TaxesContext();

        [HttpGet]
        public ActionResult EditMunicipality(int? municipalityId, int? departmentId)
        {
            if (municipalityId == null || departmentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var municipality = db.Municipalities.Find(municipalityId);

            if (municipality == null)
            {
                return HttpNotFound();
            }
            
            return View(municipality);
        }

        [HttpPost]
        public ActionResult EditMunicipality(Municipality view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty,ex.Message);

                    return View(view);
                }

                return RedirectToAction($"Details/{view.DepartmentId}");
            }

            return View(view);
        }

        public ActionResult DeleteMunicipality(int id)
        {
            var municipality = db.Municipalities.Find(id);

            if (municipality == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (municipality == null)
            {
                return HttpNotFound();
            }

            db.Municipalities.Remove(municipality);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {


                if (ex.InnerException != null &&
                  ex.InnerException.InnerException != null &&
                  ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    //ModelState.AddModelError(string.Empty, "Can't delete the record, because has related records.....");
                    ViewBag.Error = "Can't delete the record, because has related records.....";
                }
                else
                {
                    //ModelState.AddModelError(string.Empty, ex.Message);

                    ViewBag.Error = ex.Message;
                    return RedirectToAction($"Details/{municipality.DepartmentId}");
                }

            }

            return RedirectToAction($"Details/{municipality.DepartmentId}");
        }

        public ActionResult AddMunicipality(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var department = db.Departaments.Find(id);

            if (department == null)
            {
                return HttpNotFound();
            }

            var view = new Municipality
            {
                DepartmentId = department.DepartmentId,
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult AddMunicipality(Municipality view)
        {
            if (ModelState.IsValid)
            {
                db.Municipalities.Add(view);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name in the DB");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    return View(view);

                }

                return RedirectToAction($"Details/{view.DepartmentId}");
                //return RedirectToAction(string.Format("Details/{0}", view.DepartmentId));

            }

            return View(view);

        }

        // GET: Departaments
        public ActionResult Index()
        {
            var departments = db.Departaments.OrderBy(d => d.Name).ToList();

            var views = new List<DepartmentView>();

            foreach (var department in departments)
            {
                var view = new DepartmentView
                {
                    DepartmentId = department.DepartmentId,
                    MunicipalityList = department.Municipalities.ToList(),
                    Name = department.Name,
                };

                views.Add(view);
            }

            return View(views);
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var departament = db.Departaments.Find(id);

            if (departament == null)
            {
                return HttpNotFound();
            }

            var view = new DepartmentView
            {
                DepartmentId = departament.DepartmentId,
                MunicipalityList = departament.Municipalities.OrderBy(m => m.Name).ToList(),
                Name = departament.Name,
            };

            return View(view);
        }


        // GET: Departaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,Name")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Departaments.Add(departament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departament);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departaments.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,Name")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Departament departament = db.Departaments.Find(id);

            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var departament = db.Departaments.Find(id);
            db.Departaments.Remove(departament);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null &&
                     ex.InnerException.InnerException != null &&
                     ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "The record can't be delete because has related record.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return View(departament);
            }

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
