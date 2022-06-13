using KiemTra_TranDinhBao.Models;
using KiemTra_TranDinhBao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_TranDinhBao.Controllers
{
    public class HocPhanController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: HocPhan
        public ActionResult Index()
        {
            var khoahoc = from sv in data.HocPhans select sv;
            return View(khoahoc);
        }
    }
}