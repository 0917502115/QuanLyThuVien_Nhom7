using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class muontraController : Controller
    {
        // GET: muontra
        public ActionResult ListMT()
        {
            thuvienDataContext db = new thuvienDataContext();
            List<MUONTRA> dssv = (from sv in db.MUONTRAs
                                select sv).ToList();
            return View(dssv);

        }
        public ActionResult DetailsMT(string id)
        {
            thuvienDataContext db = new thuvienDataContext();
            MUONTRA s = db.MUONTRAs.FirstOrDefault(x => x.MaMuon == id);
            return View(s);
        }
        public ActionResult CreateMT()
        {
            if (Request.Form.Count > 0)
            {
                string MaMuon = GenerateRandomMaMuon();
                string TenSV = Request.Form["TenSV"];
                string TenSach = Request.Form["TenSach"];
                bool TrangThai = bool.Parse(Request.Form["TrangThai"]);
                string Ngaymuon = Request.Form["Ngaymuon"];
                string Ngaytra = Request.Form["Ngaytra"];
                while (IsMaSVExists(MaMuon))
                {
                    MaMuon = GenerateRandomMaMuon();
                }

                thuvienDataContext db = new thuvienDataContext();
                MUONTRA objmt = new MUONTRA();
                objmt.MaMuon = MaMuon;
                objmt.TenSV = TenSV;
                objmt.TenSach = TenSach;
                objmt.TrangThai = TrangThai;
                objmt.Ngaymuon = Ngaymuon;
                objmt.Ngaytra = Ngaytra;


                db.MUONTRAs.InsertOnSubmit(objmt);
                db.SubmitChanges();
                return RedirectToAction("ListMT");
            }

            return View();
        }
        private string GenerateRandomMaMuon()
        {

            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        private bool IsMaSVExists(string MaMuon)
        {
            thuvienDataContext db = new thuvienDataContext();
            return db.MUONTRAs.Any(k => k.MaMuon == MaMuon);
        }
        public ActionResult EditMT(string MaMuon)
        {
            thuvienDataContext db = new thuvienDataContext();
            MUONTRA sv = db.MUONTRAs.FirstOrDefault(x => x.MaMuon == MaMuon);
            if (sv == null)
            {
                return HttpNotFound();
            }

            if (Request.Form.Count == 0)
            {
                return View(sv);
            }

            string TenSV = Request.Form["TenSV"];
            string TenSach = Request.Form["TenSach"];
            bool TrangThai = bool.Parse(Request.Form["TrangThai"]);
            string Ngaymuon = Request.Form["Ngaymuon"];
            string Ngaytra = Request.Form["Ngaytra"];
            sv.TenSV = TenSV;
            sv.TenSach = TenSach;
            sv.TrangThai = TrangThai;
            sv.Ngaymuon = Ngaymuon;
            sv.Ngaytra = Ngaytra;
            db.SubmitChanges();
            return RedirectToAction("ListMT");
        }
        public ActionResult DeleteMT(string MaMuon)
        {
            thuvienDataContext db = new thuvienDataContext();
            MUONTRA sv = db.MUONTRAs.FirstOrDefault(x => x.MaMuon == MaMuon);
            if (sv != null)
            {
                db.MUONTRAs.DeleteOnSubmit(sv);
                db.SubmitChanges();
            }
            return RedirectToAction("ListMT");
        }
    }
}