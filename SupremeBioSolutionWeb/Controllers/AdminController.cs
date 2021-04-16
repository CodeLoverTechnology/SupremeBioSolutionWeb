using SupremeBioSolutionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupremeBioSolutionWeb.Controllers
{
    public class AdminController : Controller
    {
        private SBioSolDbEntities db = new SBioSolDbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string UserID = frm["username"].ToString();
            string Password = frm["password"].ToString();
            if(string.IsNullOrEmpty(UserID) && string.IsNullOrEmpty(Password))
            {
                //M_UserMaster userlist = from s in db.M_UserMaster.Where(x => x.UserId == UserID && x.Pwd == Password && x.Active == true);
            }
            if (Resources.SBSGlobal.AdminUser == UserID && Resources.SBSGlobal.P_Admin_User == Password)
            {
                Session["CurrentUser"] = "Admin";
                Session["EmailID"] = UserID;
                return RedirectToAction("Index", "Admin", null);
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            Session["CurrentUser"] = "";
            Session["EmailID"] = "";
            return RedirectToAction("Index", "Home", null);
        }

    }
}