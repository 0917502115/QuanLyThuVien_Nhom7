using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class theloaiController : Controller
    {
        public ActionResult ListTL()
        {
            thuvienDataContext db = new thuvienDataContext();
            List<THELOAI> dsTL = (from sv in db.THELOAIs
                                 select sv).ToList();
            return View(dsTL);

        }
        public ActionResult DetailsTL(string id)
        {
            thuvienDataContext db = new thuvienDataContext();
            THELOAI s = db.THELOAIs.FirstOrDefault(x => x.MaTL == id);
            return View(s);
        }
        public ActionResult CreateTL()
        {
            if (Request.Form.Count > 0)
            {
                string MaTL = GenerateRandomMaTL();
                string TenTL = Request.Form["TenTL"];
                
                while (IsMaSVExists(MaTL))
                {
                    MaTL = GenerateRandomMaTL();
                }

                thuvienDataContext db = new thuvienDataContext();
                THELOAI objTL = new THELOAI();
                objTL.MaTL = MaTL;
                objTL.TenTL = TenTL;
                


                db.THELOAIs.InsertOnSubmit(objTL);
                db.SubmitChanges();
                return RedirectToAction("ListTL");
            }

            return View();
        }
        private string GenerateRandomMaTL()
        {

            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private bool IsMaSVExists(string MaTL)
        {
            thuvienDataContext db = new thuvienDataContext();
            return db.THELOAIs.Any(k => k.MaTL == MaTL);
        }
        public ActionResult EditTL(string MaTL)
        {
            thuvienDataContext db = new thuvienDataContext();
            THELOAI tl = db.THELOAIs.FirstOrDefault(x => x.MaTL == MaTL);

            if (tl == null)
            {
                return HttpNotFound();
            }

            if (Request.Form.Count == 0)
            {
                return View(tl);
            }


            string TenTL= Request.Form["TenTL"];
            tl.TenTL = TenTL;

            db.SubmitChanges();
            return RedirectToAction("ListTL");
        }
        public ActionResult DeleteTL(string MaTL)
        {
            thuvienDataContext db = new thuvienDataContext();
            THELOAI tl = db.THELOAIs.FirstOrDefault(x => x.MaTL == MaTL);
            if (tl != null)
            {
                db.THELOAIs.DeleteOnSubmit(tl);
                db.SubmitChanges();
            }
            return RedirectToAction("ListTL");
        }

    }
}