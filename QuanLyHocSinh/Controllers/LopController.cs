using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class LopController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public LopController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["listLop"] = dBHelper.GetLop();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int idKhoi)
        {
            ViewData["listLop"] = dBHelper.GetLop();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.LopDetail = dBHelper.GetLopByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            LopVM lVM = new LopVM()
            {
                LopId = id,
                LopName = dBHelper.GetLopByID(id).LopName
            };
            if (lVM == null) return NotFound();
            else return View(lVM);
        }
        [HttpPost]
        public IActionResult Edit(LopVM lopVM)
        {

            {
                Lop newLop = new Lop()
                {
                    LopID = lopVM.LopId,
                    LopName = lopVM.LopName,
                    KhoiID = lopVM.KhoiId,
                    KhoiName = lopVM.KhoiName,
                    SiSo=lopVM.Siso,

                };
                dBHelper.EditLop(newLop);
                return RedirectToAction("Index");
            }
            return View(lopVM);
        }

        public IActionResult Delete(int id)
        {
            LopVM lVM = new LopVM()
            {
                LopId = id,
                LopName = dBHelper.GetLopByID(id).LopName
            };
            if (lVM == null) return NotFound();
            else return View(lVM);
        }
        [HttpPost]
        public IActionResult Delete(LopVM lopVM)
        {

            {
                dBHelper.DeleteLop(lopVM.LopId);
                return RedirectToAction("Index");
            }
            return View(lopVM);
        }

        [HttpPost]
        public IActionResult Create(LopVM lopVM)
        {


            Lop lop = new Lop()
            {

                LopID = lopVM.LopId,
                LopName = lopVM.LopName,
                KhoiID = lopVM.KhoiId,
                KhoiName = lopVM.KhoiName,
                SiSo = lopVM.Siso,

            };
            dBHelper.InsertLop(lop);
            return RedirectToAction("Index");
        }

        public ActionResult Search(int idlopk)
        {
            if (idlopk == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<Lop> loclop = dBHelper.LocKhoiLop(idlopk);
                return View("Search", loclop);
            }
        }

    }
}
