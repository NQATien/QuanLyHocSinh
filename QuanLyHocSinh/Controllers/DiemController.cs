using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class DiemController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public DiemController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            ViewData["listDiem"] = dBHelper.Getdiem();
            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.DiemDetail = dBHelper.GetdiemByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            DiemVM kVM = new DiemVM()
            {
                DiemId = id,
                HocSinhName = dBHelper.GetdiemByID(id).HocSinhName
            };
            if (kVM == null) return NotFound();
            else return View(kVM);
        }
        [HttpPost]
        public IActionResult Edit(DiemVM diemVM)
        {

            {
                Diem newDiem = new Diem()
                {
                    DiemID = diemVM.DiemId,
                    HocSinhName = diemVM.HocSinhName,
                    DiemHK1 = diemVM.Diemhk1,
                    DiemHK2 = diemVM.Diemhk2,
                    DiemHK3 = diemVM.Diemhk3,



                };
                dBHelper.Editdiem(newDiem);
                return RedirectToAction("Index");
            }
            return View(diemVM);
        }

        public IActionResult Delete(int id)
        {
            DiemVM dVM = new DiemVM()
            {
                DiemId = id,
                HocSinhName = dBHelper.GetdiemByID(id).HocSinhName
            };
            if (dVM == null) return NotFound();
            else return View(dVM);
        }
        [HttpPost]
        public IActionResult Delete(DiemVM diemVM)
        {

            {
                dBHelper.Deletediem(diemVM.DiemId);
                return RedirectToAction("Index");
            }
            return View(diemVM);
        }

        [HttpPost]
        public IActionResult Create(DiemVM diemVM)
        {


            Diem diem = new Diem()
            {

                DiemID = diemVM.DiemId,
                HocSinhName = diemVM.HocSinhName,
                DiemHK1= diemVM.Diemhk1,
                DiemHK2 = diemVM.Diemhk2,
                DiemHK3 = diemVM.Diemhk3,

            };
            dBHelper.Insertdiem(diem);
            return RedirectToAction("Index");
        }

    }
}
