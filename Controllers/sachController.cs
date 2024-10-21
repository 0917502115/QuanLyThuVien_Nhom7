using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class sachController : Controller
    {
        // GET: sach
        public ActionResult ListSach()
        {
            thuvienDataContext db = new thuvienDataContext();
            List<SACH> dsSach = (from sv in db.SACHes
                                           select sv).ToList();
            return View(dsSach);

        }
        public ActionResult ListTL1()
        {
            thuvienDataContext db = new thuvienDataContext();
            List<THELOAI> dsTL = (from sv in db.THELOAIs
                                  select sv).ToList();
            return View(dsTL);

        }
        public ActionResult DetailsSach(string id)
        {
            thuvienDataContext db = new thuvienDataContext();
            SACH s = db.SACHes.FirstOrDefault(x => x.MaSach == id);
            return View(s);
        }
        public ActionResult CreateSach()
        {
            if (Request.Form.Count > 0)
            {
                string MaSach = GenerateRandomMaSach();
                string TenSach = Request.Form["TenSach"];
                string Theloai = Request.Form["Theloai"];
                string MaTL = Request.Form["MaTL"];
                string Tacgia = Request.Form["Tacgia"];
                int NamXB = int.Parse(Request.Form["NamXB"]);
                while (IsMaSVExists(MaSach))
                {
                    MaSach = GenerateRandomMaSach();
                }

                thuvienDataContext db = new thuvienDataContext();
                SACH objSach  = new SACH();
                objSach.MaSach = MaSach;
                objSach.TenSach = TenSach;
                objSach.Theloai = Theloai;
                objSach.MaTL = MaTL;
                objSach .Tacgia = Tacgia;
                objSach.NamXB = NamXB;


                db.SACHes.InsertOnSubmit(objSach);
                db.SubmitChanges();
                return RedirectToAction("ListSach");
            }

            return View();
        }
        private string GenerateRandomMaSach()
        {

            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private bool IsMaSVExists(string MaSach)
        {
            thuvienDataContext db = new thuvienDataContext();
            return db.SACHes.Any(k => k.MaSach == MaSach);
        }
        public ActionResult EditSach(string MaSach)
        {
            thuvienDataContext db = new thuvienDataContext();
            SACH sach = db.SACHes.FirstOrDefault(x => x.MaSach == MaSach);

            if (sach == null)
            {
                return HttpNotFound();
            }

            if (Request.Form.Count == 0)
            {
                return View(sach);
            }


            string TenSach = Request.Form["TenSach"];
            string Theloai = Request.Form["Theloai"];
            string MaTL = Request.Form["MaTL"];
            string Tacgia = Request.Form["Tacgia"];
            int NamXB = int.Parse(Request.Form["NamXB"]);
            sach.TenSach = TenSach;
            sach.Theloai = Theloai;
            sach.MaTL = MaTL;
            sach.Tacgia = Tacgia;
            sach.NamXB = NamXB;
            db.SubmitChanges();
            return RedirectToAction("ListSach");
        }
        public ActionResult DeleteSach(string MaSach)
        {
            thuvienDataContext db = new thuvienDataContext();
            SACH sach = db.SACHes.FirstOrDefault(x => x.MaSach == MaSach);
            if (sach != null)
            {
                db.SACHes.DeleteOnSubmit(sach);
                db.SubmitChanges();
            }
            return RedirectToAction("ListSach");
        }
    }
}