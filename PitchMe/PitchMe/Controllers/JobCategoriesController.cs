using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PitchMe.Models;
using PitchMe.Models.Implementation;

namespace PitchMe.Controllers
{
    public class JobCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.JobCategories.ToListAsync());
        }

        // GET: JobCategories/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = await db.JobCategories.FindAsync(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // GET: JobCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Description,DateCreated,DateModified")] JobCategory jobCategory)
        {
            if (ModelState.IsValid)
            {
                db.JobCategories.Add(jobCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobCategory);
        }

        // GET: JobCategories/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = await db.JobCategories.FindAsync(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // POST: JobCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,DateCreated,DateModified")] JobCategory jobCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobCategory);
        }

        // GET: JobCategories/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = await db.JobCategories.FindAsync(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // POST: JobCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            JobCategory jobCategory = await db.JobCategories.FindAsync(id);
            db.JobCategories.Remove(jobCategory);
            await db.SaveChangesAsync();
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
