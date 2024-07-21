using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class HocKyController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HocKyController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listHocKy"] = dBHelper.Gethk();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.HocKyDetail = dBHelper.GethkByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            HocKyVM hkVM = new HocKyVM()
            {
                HocKyId = id,
                HocKyName = dBHelper.GethkByID(id).HocKyName
            };
            if (hkVM == null) return NotFound();
            else return View(hkVM);
        }
        [HttpPost]
        public IActionResult Edit(HocKyVM hockyVM)
        {

            {
                HocKy newHocky = new HocKy()
                {
                    HocKyID=hockyVM.HocKyId,
                    HocKyName=hockyVM.HocKyName,
                    NamHocID = hockyVM.NamHocId,
                    NamHocName = hockyVM.NamHocName,




                };
                dBHelper.Edithk(newHocky);
                return RedirectToAction("Index");
            }
            return View(hockyVM);
        }

        public IActionResult Delete(int id)
        {
            HocKyVM hkVM = new HocKyVM()
            {
                HocKyId = id,
                HocKyName = dBHelper.GethkByID(id).HocKyName
            };
            if (hkVM == null) return NotFound();
            else return View(hkVM);
        }
        [HttpPost]
        public IActionResult Delete(HocKyVM hockyVM)
        {

            {
                dBHelper.Deletehk(hockyVM.HocKyId);
                return RedirectToAction("Index");
            }
            return View(hockyVM);
        }

        [HttpPost]
        public IActionResult Create(HocKyVM hockyVM)
        {


            HocKy hocky = new HocKy()
            {
                HocKyID= hockyVM.HocKyId,
                HocKyName = hockyVM.HocKyName,
                NamHocID = hockyVM.NamHocId,
                NamHocName = hockyVM.NamHocName,


            };
            dBHelper.Inserthk(hocky);
            return RedirectToAction("Index");
        }

    }
}
