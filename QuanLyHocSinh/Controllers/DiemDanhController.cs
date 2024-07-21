// ThoiKhoaBieuController.cs
using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class DiemDanhController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DiemDanhController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["listDiemDanh"] = dBHelper.GetDiemDanh();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int idDiemDanh)
        {
            ViewData["listDiemDanh"] = dBHelper.GetDiemDanh();

            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.DiemDanhDetail = dBHelper.GetDiemDanhByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            DiemDanhVM ddVM = new DiemDanhVM()
            {
                DiemDanhId = id,
                MonName = dBHelper.GetDiemDanhByID(id).MonName,
                Ngay = dBHelper.GetDiemDanhByID(id).Ngay,
                Tiet = dBHelper.GetDiemDanhByID(id).Tiet,
                HocSinhName = dBHelper.GetDiemDanhByID(id).HocSinhName
            };
            if (ddVM == null) return NotFound();
            else return View(ddVM);
        }
        [HttpPost]
        public IActionResult Edit(DiemDanhVM DiemDanhVM)
        {

            {
                DiemDanh newDiemDanh = new DiemDanh()
                {
                    DiemDanhID = DiemDanhVM.DiemDanhId,
                    MonName = DiemDanhVM.MonName,
                    Ngay = DiemDanhVM.Ngay,
                    Tiet = DiemDanhVM.Tiet,
                    HocSinhName = DiemDanhVM.HocSinhName
                };
                dBHelper.EditDiemDanh(newDiemDanh);
                return RedirectToAction("Index");
            }
            return View(DiemDanhVM);
        }
        public IActionResult Delete(int id)
        {
            DiemDanhVM ddVM = new DiemDanhVM()
            {
                DiemDanhId = id,
                MonName = dBHelper.GetDiemDanhByID(id).MonName,
                Ngay = dBHelper.GetDiemDanhByID(id).Ngay,
                Tiet = dBHelper.GetDiemDanhByID(id).Tiet,
                HocSinhName = dBHelper.GetDiemDanhByID(id).HocSinhName
            };
            if (ddVM == null) return NotFound();
            else return View(ddVM);
        }
        [HttpPost]
        public IActionResult Delete(DiemDanhVM diemdanhVM)
        {

            {
                dBHelper.DeleteDiemDanh(diemdanhVM.DiemDanhId);
                return RedirectToAction("Index");
            }
            return View(diemdanhVM);
        }

        [HttpPost]
        public IActionResult Create(DiemDanhVM DiemDanhVM)
        {


            DiemDanh diemdanh = new DiemDanh()
            {

                DiemDanhID = DiemDanhVM.DiemDanhId,
                MonName = DiemDanhVM.MonName,
                Ngay = DiemDanhVM.Ngay,
                Tiet = DiemDanhVM.Tiet,
                HocSinhName = DiemDanhVM.HocSinhName
            };
            dBHelper.InsertDiemDanh(diemdanh);
            return RedirectToAction("Index");
        }
    }
}
