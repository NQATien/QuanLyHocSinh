using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class BoMonController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BoMonController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listBoMon"] = dBHelper.Getbm();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.BoMonDetail = dBHelper.GetbmByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            BoMonVM bmVM = new BoMonVM()
            {
                BoMonId = id,
                BoMonName = dBHelper.GetbmByID(id).BoMonName,
            };
            if (bmVM == null) return NotFound();
            else return View(bmVM);
        }
        [HttpPost]
        public IActionResult Edit(BoMonVM bomonVM)
        {

            {
                BoMon newBomon = new BoMon()
                {
                    BoMonID = bomonVM.BoMonId,
                    BoMonName = bomonVM.BoMonName,




                };
                dBHelper.Editbm(newBomon);
                return RedirectToAction("Index");
            }
            return View(bomonVM);
        }

        public IActionResult Delete(int id)
        {
            BoMonVM bmVM = new BoMonVM()
            {
                BoMonId = id,
                BoMonName = dBHelper.GetbmByID(id).BoMonName
            };
            if (bmVM == null) return NotFound();
            else return View(bmVM);
        }
        [HttpPost]
        public IActionResult Delete(BoMonVM bomonVM)
        {

            {
                dBHelper.Deletebm(bomonVM.BoMonId);
                return RedirectToAction("Index");
            }
            return View(bomonVM);
        }

        [HttpPost]
        public IActionResult Create(BoMonVM bomonVM)
        {


            BoMon bomon = new BoMon()
            {

                BoMonID = bomonVM.BoMonId,
                BoMonName = bomonVM.BoMonName,


            };
            dBHelper.Insertbm(bomon);
            return RedirectToAction("Index");
        }

    }
}
