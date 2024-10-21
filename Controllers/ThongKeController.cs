using QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyThuVien.Controllers
{
    public class ThongKeController : Controller
    {
        public ActionResult Top5SachMuon()
        {
            thuvienDataContext db = new thuvienDataContext();

            var top5Books = db.MUONTRAs
                .GroupBy(mt => mt.TenSach)
                .Select(group => new
                {
                    TenSach = group.Key,
                    SoLuotMuon = group.Count()
                })
                .OrderByDescending(x => x.SoLuotMuon)
                .Take(5)
                .ToList();

            List<TopSachMuonViewModel> top5BooksViewModel = new List<TopSachMuonViewModel>();
            foreach (var item in top5Books)
            {
                top5BooksViewModel.Add(new TopSachMuonViewModel
                {
                    TenSach = item.TenSach,
                    SoLuotMuon = item.SoLuotMuon
                });
            }

            return View(top5BooksViewModel);
        }

        public class TopSachMuonViewModel
        {
            public string TenSach { get; set; }
            public int SoLuotMuon { get; set; }
        }
    }

}