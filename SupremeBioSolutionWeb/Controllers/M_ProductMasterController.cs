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
using SupremeBioSolutionWeb.App_Code;

namespace SupremeBioSolutionWeb.Controllers
{
    public class M_ProductMasterController : Controller
    {
        private SBioSolDbEntities db = new SBioSolDbEntities();

        // GET: M_ProductMaster
        public async Task<ActionResult> Index()
        {
            var m_ProductMaster = db.M_ProductMaster.Include(m => m.M_MasterTable);
            return View(await m_ProductMaster.ToListAsync());
        }

        // GET: M_ProductMaster/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // GET: M_ProductMaster/Create
        public ActionResult Create()
        {
            ViewBag.TypeOfProduct = new SelectList(db.M_MasterTable, "MasterId", "MasterValue");
            return View();
        }

        // POST: M_ProductMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,TypeOfProduct,ProductName,SubTag,COMPOSITION,DOSAGE,Prd_FUNCTION,PRESENTATION,Prod_Pics,Remarks")] M_ProductMaster m_ProductMaster)
        {
            if (ModelState.IsValid)
            {
                string FullPathWithFileName1 = null;
                string FolderPathForImage1 = null;
                string FolderPath = Server.MapPath(Resources.SBSGlobal.ProductPath) + "\\" + m_ProductMaster.ProductName.Trim().Replace(" ","_");
                if (CommonFunction.IsFolderExist(FolderPath))
                {
                    if (!string.IsNullOrEmpty(Request.Files["ImagesUpload"].FileName))
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            FullPathWithFileName1 = FolderPath + "\\" + Request.Files[i].FileName;
                            Request.Files[i].SaveAs(FullPathWithFileName1);
                        }
                    }
                }
                m_ProductMaster.CreatedBy = Session["CurrentUser"].ToString();
                m_ProductMaster.CreatedDate = DateTime.Now;
                m_ProductMaster.ModifiedBy = Session["CurrentUser"].ToString();
                m_ProductMaster.ModifiedDate = DateTime.Now;
                m_ProductMaster.Active = true;
                db.M_ProductMaster.Add(m_ProductMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TypeOfProduct = new SelectList(db.M_MasterTable, "MasterId", "MasterValue", m_ProductMaster.TypeOfProduct);
            return View(m_ProductMaster);
        }

        // GET: M_ProductMaster/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeOfProduct = new SelectList(db.M_MasterTable, "MasterId", "MasterValue", m_ProductMaster.TypeOfProduct);
            return View(m_ProductMaster);
        }

        // POST: M_ProductMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,TypeOfProduct,ProductName,SubTag,COMPOSITION,DOSAGE,Prd_FUNCTION,PRESENTATION,Prod_Pics,Remarks,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_ProductMaster m_ProductMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_ProductMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TypeOfProduct = new SelectList(db.M_MasterTable, "MasterId", "MasterValue", m_ProductMaster.TypeOfProduct);
            return View(m_ProductMaster);
        }

        // GET: M_ProductMaster/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            if (m_ProductMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_ProductMaster);
        }

        // POST: M_ProductMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            M_ProductMaster m_ProductMaster = await db.M_ProductMaster.FindAsync(id);
            db.M_ProductMaster.Remove(m_ProductMaster);
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
