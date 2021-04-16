using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupremeBioSolutionWeb.Models;

namespace SupremeBioSolutionWeb.Controllers
{
    public class M_UserMasterController : Controller
    {
        private SBioSolDbEntities db = new SBioSolDbEntities();

        // GET: M_UserMaster
        public async Task<ActionResult> Index()
        {
            return View(await db.M_UserMaster.ToListAsync());
        }

        // GET: M_UserMaster/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_UserMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Pwd,Name,Active")] M_UserMaster m_UserMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_UserMaster.Add(m_UserMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_UserMaster);
        }

        // POST: M_UserMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,Pwd,Name,Active")] M_UserMaster m_UserMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_UserMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_UserMaster);
        }

        // POST: M_UserMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            db.M_UserMaster.Remove(m_UserMaster);
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
