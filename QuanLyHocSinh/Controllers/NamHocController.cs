using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class NamHocController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public NamHocController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listNamHoc"] = dBHelper.Getnamhoc();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            NamHocVM nVM = new NamHocVM()
            {
                NamHocId = id,
                NamHocName = dBHelper.GetnamhocByID(id).NamHocName
            };
            if (nVM == null) return NotFound();
            else return View(nVM);
        }
        [HttpPost]
        public IActionResult Edit(NamHocVM namhocVM)
        {

            {
                NamHoc newNamhoc = new NamHoc()
                {
                    NamHocID = namhocVM.NamHocId,
                    NamHocName = namhocVM.NamHocName,
                    



                };
                dBHelper.Editnamhoc(newNamhoc);
                return RedirectToAction("Index");
            }
            return View(namhocVM);
        }

        public IActionResult Delete(int id)
        {
            NamHocVM nVM = new NamHocVM()
            {
                NamHocId = id,
                NamHocName = dBHelper.GetnamhocByID(id).NamHocName
            };
            if (nVM == null) return NotFound();
            else return View(nVM);
        }
        [HttpPost]
        public IActionResult Delete(NamHocVM namhocVM)
        {

            {
                dBHelper.Deletenamhoc(namhocVM.NamHocId);
                return RedirectToAction("Index");
            }
            return View(namhocVM);
        }

        [HttpPost]
        public IActionResult Create(NamHocVM namhocVM)
        {


            NamHoc namhoc = new NamHoc()
            {

                NamHocID = namhocVM.NamHocId,
                NamHocName = namhocVM.NamHocName,
                

            };
            dBHelper.Insertnamhoc(namhoc);
            return RedirectToAction("Index");
        }

    }
}
