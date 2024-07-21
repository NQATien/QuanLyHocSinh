using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class GiaoVienController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GiaoVienController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listGiaoVien"] = dBHelper.GetGiaoVien();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.GiaoVienDetail = dBHelper.GetGiaoVienByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            GiaoVienVM gVM = new GiaoVienVM()
            {
                GiaoVienId = id,
                GiaoVienName = dBHelper.GetGiaoVienByID(id).GiaoVienName
            };
            if (gVM == null) return NotFound();
            else return View(gVM);
        }
        [HttpPost]
        public IActionResult Edit(GiaoVienVM giaovienVM)
        {

            {
                GiaoVien newGiaovien = new GiaoVien()
                {
                    GiaoVienID = giaovienVM.GiaoVienId,
                    GiaoVienName = giaovienVM.GiaoVienName,
                    GioiTinh = giaovienVM.GioiTinh,
                    LopID = giaovienVM.LopId,
                    LopName = giaovienVM.LopName,
                };
                dBHelper.EditGiaoVien(newGiaovien);
                return RedirectToAction("Index");
            }
            return View(giaovienVM);
        }

        public IActionResult Delete(int id)
        {
            GiaoVienVM gVM = new GiaoVienVM()
            {
                GiaoVienId = id,
                GiaoVienName = dBHelper.GetGiaoVienByID(id).GiaoVienName
            };
            if (gVM == null) return NotFound();
            else return View(gVM);
        }
        [HttpPost]
        public IActionResult Delete(GiaoVienVM giaovienVM)
        {

            {
                dBHelper.DeleteGiaoVien(giaovienVM.GiaoVienId);
                return RedirectToAction("Index");
            }
            return View(giaovienVM);
        }

        [HttpPost]
        public IActionResult Create(GiaoVienVM giaovienVM)
        {
            

            GiaoVien giaovien = new GiaoVien()
            {

                GiaoVienName = giaovienVM.GiaoVienName,
                GioiTinh = giaovienVM.GioiTinh,
                LopID = giaovienVM.LopId,
                LopName = giaovienVM.LopName,
             
            };
            dBHelper.InsertGiaoVien(giaovien);
            return RedirectToAction("Index");
        }

    }
}

