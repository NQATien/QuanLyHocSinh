using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class MonController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MonController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listMon"] = dBHelper.Getm();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.MonDetail = dBHelper.GetmByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            MonVM mVM = new MonVM()
            {
                MonId = id,
                MonName = dBHelper.GetmByID(id).MonName,
            };
            if (mVM == null) return NotFound();
            else return View(mVM);
        }
        [HttpPost]
        public IActionResult Edit(MonVM monVM)
        {

            {
                Mon newMon = new Mon()
                {
                    MonID = monVM.MonId,
                    MonName = monVM.MonName,
                    BoMonID = monVM.BoMonId,
                    BoMonName = monVM.BoMonName,
                    GiaoVienID = monVM.GiaoVienId,
                    GiaoVienName = monVM.GiaoVienName,




                };
                dBHelper.Editm(newMon);
                return RedirectToAction("Index");
            }
            return View(monVM);
        }

        public IActionResult Delete(int id)
        {
            MonVM mVM = new MonVM()
            {
                MonId = id,
                MonName = dBHelper.GetmByID(id).MonName
            };
            if (mVM == null) return NotFound();
            else return View(mVM);
        }
        [HttpPost]
        public IActionResult Delete(MonVM monVM)
        {

            {
                dBHelper.Deletem(monVM.MonId);
                return RedirectToAction("Index");
            }
            return View(monVM);
        }

        [HttpPost]
        public IActionResult Create(MonVM monVM)
        {


            Mon mon = new Mon()
            {

                MonID = monVM.MonId,
                MonName = monVM.MonName,
                BoMonID = monVM.BoMonId,
                BoMonName = monVM.BoMonName,
                GiaoVienID = monVM.GiaoVienId,
                GiaoVienName = monVM.GiaoVienName,

            };
            dBHelper.Insertm(mon);
            return RedirectToAction("Index");
        }

    }
}
