// ThoiKhoaBieuController.cs
using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class ThoiKhoaBieuController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ThoiKhoaBieuController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["listThoiKhoaBieu"] = dBHelper.GetThoiKhoaBieu();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int idThoiKhoaBieu)
        {
            ViewData["listThoiKhoaBieu"] = dBHelper.GetThoiKhoaBieu();

            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.ThoiKhoaBieuDetail = dBHelper.GetThoiKhoaBieuByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ThoiKhoaBieuVM tVM = new ThoiKhoaBieuVM()
            {
                ThoiKhoaBieuId = id,
                ThoiKhoaBieuName = dBHelper.GetThoiKhoaBieuByID(id).ThoiKhoaBieuName
            };
            if (tVM == null) return NotFound();
            else return View(tVM);
        }
        [HttpPost]
        public IActionResult Edit(ThoiKhoaBieuVM ThoiKhoaBieuVM)
        {

            {
                ThoiKhoaBieu newThoiKhoaBieu = new ThoiKhoaBieu()
                {
                    ThoiKhoaBieuID = ThoiKhoaBieuVM.ThoiKhoaBieuId,
                    ThoiKhoaBieuName = ThoiKhoaBieuVM.ThoiKhoaBieuName,
                    GiaoVienName = ThoiKhoaBieuVM.GiaoVienName,
                    MonName = ThoiKhoaBieuVM.MonName,
                    Ngay = ThoiKhoaBieuVM.Ngay,
                    Tiet = ThoiKhoaBieuVM.Tiet

                };
                dBHelper.EditThoiKhoaBieu(newThoiKhoaBieu);
                return RedirectToAction("Index");
            }
            return View(ThoiKhoaBieuVM);
        }
        public IActionResult Delete(int id)
        {
            ThoiKhoaBieuVM tkbVM = new ThoiKhoaBieuVM()
            {
                ThoiKhoaBieuId = id,
                ThoiKhoaBieuName = dBHelper.GetThoiKhoaBieuByID(id).ThoiKhoaBieuName,
                GiaoVienName = dBHelper.GetThoiKhoaBieuByID(id).GiaoVienName,
                MonName = dBHelper.GetThoiKhoaBieuByID(id).MonName
            };
            if (tkbVM == null) return NotFound();
            else return View(tkbVM);
        }
        [HttpPost]
        public IActionResult Delete(ThoiKhoaBieuVM thoikhoabieuVM)
        {

            {
                dBHelper.DeleteThoiKhoaBieu(thoikhoabieuVM.ThoiKhoaBieuId);
                return RedirectToAction("Index");
            }
            return View(thoikhoabieuVM);
        }

        [HttpPost]
        public IActionResult Create(ThoiKhoaBieuVM ThoiKhoaBieuVM)
        {


            ThoiKhoaBieu thoikhoabieu = new ThoiKhoaBieu()
            {

                ThoiKhoaBieuID = ThoiKhoaBieuVM.ThoiKhoaBieuId,
                ThoiKhoaBieuName = ThoiKhoaBieuVM.ThoiKhoaBieuName,
                GiaoVienName = ThoiKhoaBieuVM.GiaoVienName,
                MonName = ThoiKhoaBieuVM.MonName,
                Ngay = ThoiKhoaBieuVM.Ngay,
                Tiet = ThoiKhoaBieuVM.Tiet


            };
            dBHelper.InsertThoiKhoaBieu(thoikhoabieu);
            return RedirectToAction("Index");
        }
    }
}
