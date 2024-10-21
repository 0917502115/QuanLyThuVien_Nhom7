using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class thesvController : Controller
    {
        // GET: thesv
        public ActionResult ListSV()
        {
            thuvienDataContext db = new thuvienDataContext();
            List<THESV> dssv = (from sv in db.THESVs
                                 select sv).ToList();
            return View(dssv);

        }
        public ActionResult DetailsSV(string id)
        {
            thuvienDataContext db = new thuvienDataContext();
            THESV s = db.THESVs.FirstOrDefault(x => x.MaSV == id);
            return View(s);
        }
        public ActionResult CreateSV()
        {
            if (Request.Form.Count > 0)
            {
                string MaSV = GenerateRandomMaSV();
                string TenSV = Request.Form["TenSV"];
                string Lop = Request.Form["Lop"];
                int Khoa = int.Parse(Request.Form["Khoa"]);
                int Namsinh = int.Parse(Request.Form["Namsinh"]);
                string SDT = Request.Form["SDT"];
                string Quequan = Request.Form["Quequan"];
                while (IsMaSVExists(MaSV))
                {
                    MaSV = GenerateRandomMaSV();
                }

                thuvienDataContext db = new thuvienDataContext();
                THESV objSV = new THESV();
                objSV.MaSV = MaSV;
                objSV.TenSV = TenSV;
                objSV.Lop = Lop   ;
                objSV.Khoa = Khoa;
                objSV.Namsinh = Namsinh;
                objSV.SDT = SDT;
                objSV.Quequan = Quequan;


                db.THESVs.InsertOnSubmit(objSV);
                db.SubmitChanges();
                return RedirectToAction("ListSV");
            }

            return View();
        }
        private string GenerateRandomMaSV()
        {

            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private bool IsMaSVExists(string MaSV)
        {
            thuvienDataContext db = new thuvienDataContext();
            return db.THESVs.Any(k => k.MaSV == MaSV);
        }
        public ActionResult EditSV(string MaSV)
        {
            thuvienDataContext db = new thuvienDataContext();
            THESV sv = db.THESVs.FirstOrDefault(x => x.MaSV == MaSV);

            if (sv == null)
            {
                return HttpNotFound();
            }

            if (Request.Form.Count == 0)
            {
                return View(sv);
            }


            string TenSV = Request.Form["TenSV"];
            string Lop = Request.Form["Lop"];
            int Khoa = int.Parse(Request.Form["Khoa"]);
            int Namsinh = int.Parse(Request.Form["Namsinh"]);
            string SDT = Request.Form["SDT"];
            string Quequan = Request.Form["Quequan"];
            sv.TenSV = TenSV;
            sv.Lop = Lop;
            sv.Khoa = Khoa;
            sv.Namsinh = Namsinh;
            sv.SDT = SDT;
            sv.Quequan = Quequan;
            db.SubmitChanges();
            return RedirectToAction("ListSV");
        }
        public ActionResult DeleteSV(string MaSV)
        {
            thuvienDataContext db = new thuvienDataContext();
            THESV sv = db.THESVs.FirstOrDefault(x => x.MaSV == MaSV);
            if (sv != null)
            {
                db.THESVs.DeleteOnSubmit(sv);
                db.SubmitChanges();
            }
            return RedirectToAction("ListSV");
        }
    }
}