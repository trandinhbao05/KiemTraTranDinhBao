using KiemTra_TranDinhBao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_TranDinhBao.Controllers
{
    public class SinhVienController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: SinhVien
        public ActionResult Index()
        {
            var all_sinhvien = from sv in data.SinhViens select sv;
            return View(all_sinhvien);
        }
        //-------------Detail-------------------
        /*public ActionResult Detail(int id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }*/
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_masv = collection["masv"];
            var E_tensv = collection["tensv"];
            var E_gioitinh = collection["gioitinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);

            var E_hinh = collection["hinh"];
            var E_manganh = collection["manganh"];

            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_masv.ToString();
                s.tensv = E_tensv.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh.ToString();
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("SinhVien");
            }
            return this.Create();
        }

        //-------------Edit-------------------
        public ActionResult Edit(string id)
        {
            var E_category = data.SinhViens.First(m => m.MaSV == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var sinhvien = data.SinhViens.First(m => m.MaSV == id);
            var E_tensv = collection["tensv"];
            sinhvien.MaSV = id;
            if (string.IsNullOrEmpty(E_tensv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sinhvien.tensv = E_tensv;
                UpdateModel(sinhvien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
    }
}
 