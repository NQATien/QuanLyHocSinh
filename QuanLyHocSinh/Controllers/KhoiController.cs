using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class KhoiController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public KhoiController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listKhoi"] = dBHelper.Getkhoi();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.KhoiDetail = dBHelper.GetkhoiByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            KhoiVM kVM = new KhoiVM()
            {
                KhoiId = id,
                KhoiName = dBHelper.GetkhoiByID(id).KhoiName
            };
            if (kVM == null) return NotFound();
            else return View(kVM);
        }
        [HttpPost]
        public IActionResult Edit(KhoiVM khoiVM)
        {

            {
                Khoi newKhoi = new Khoi()
                {
                    KhoiID = khoiVM.KhoiId,
                    KhoiName = khoiVM.KhoiName,
                   SoLuongHS= khoiVM.SoLuonghs
             
                   

                };
                dBHelper.Editkhoi(newKhoi);
                return RedirectToAction("Index");
            }
            return View(khoiVM);
        }

        public IActionResult Delete(int id)
        {
            KhoiVM kVM = new KhoiVM()
            {
                KhoiId = id,
                KhoiName = dBHelper.GetkhoiByID(id).KhoiName
            };
            if (kVM == null) return NotFound();
            else return View(kVM);
        }
        [HttpPost]
        public IActionResult Delete(KhoiVM khoiVM)
        {

            {
                dBHelper.Deletekhoi(khoiVM.KhoiId);
                return RedirectToAction("Index");
            }
            return View(khoiVM);
        }

        [HttpPost]
        public IActionResult Create(KhoiVM khoiVM)
        {


            Khoi khoi = new Khoi()
            {

                KhoiID = khoiVM.KhoiId,
                KhoiName = khoiVM.KhoiName,
                SoLuongHS = khoiVM.SoLuonghs,

            };
            dBHelper.Insertkhoi(khoi);
            return RedirectToAction("Index");
        }

    }
}
