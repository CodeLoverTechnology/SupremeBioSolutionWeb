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
    public class M_MasterTableController : Controller
    {
        private SBioSolDbEntities db = new SBioSolDbEntities();

        // GET: M_MasterTable
        public async Task<ActionResult> Index()
        {
            return View(await db.M_MasterTable.ToListAsync());
        }

        // GET: M_MasterTable/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // GET: M_MasterTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: M_MasterTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MasterId,MasterValue,MasterTable")] M_MasterTable m_MasterTable)
        {
            if (ModelState.IsValid)
            {
                db.M_MasterTable.Add(m_MasterTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(m_MasterTable);
        }

        // GET: M_MasterTable/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // POST: M_MasterTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MasterId,MasterValue,MasterTable")] M_MasterTable m_MasterTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_MasterTable).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(m_MasterTable);
        }

        // GET: M_MasterTable/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            if (m_MasterTable == null)
            {
                return HttpNotFound();
            }
            return View(m_MasterTable);
        }

        // POST: M_MasterTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_MasterTable m_MasterTable = await db.M_MasterTable.FindAsync(id);
            db.M_MasterTable.Remove(m_MasterTable);
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
