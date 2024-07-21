// ThoiKhoaBieuController.cs
using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class ThongBaoController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ThongBaoController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["listThongBao"] = dBHelper.GetThongBao();
            return View();
        }
        [HttpPost]
        public IActionResult Index(int idThongBao)
        {
            ViewData["listThongBao"] = dBHelper.GetThongBao();

            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.ThongBaoDetail = dBHelper.GetThongBaoByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ThongBaoVM tbVM = new ThongBaoVM()
            {
                ThongBaoId = id,
                ThongBaoName = dBHelper.GetThongBaoByID(id).ThongBaoName,
                ThongTin = dBHelper.GetThongBaoByID(id).ThongTin
            };
            if (tbVM == null) return NotFound();
            else return View(tbVM);
        }
        [HttpPost]
        public IActionResult Edit(ThongBaoVM ThongBaoVM)
        {

            {
                ThongBao newThongBao = new ThongBao()
                {
                    ThongBaoID = ThongBaoVM.ThongBaoId,
                    ThongBaoName = ThongBaoVM.ThongBaoName
                };
                dBHelper.EditThongBao(newThongBao);
                return RedirectToAction("Index");
            }
            return View(ThongBaoVM);
        }
        public IActionResult Delete(int id)
        {
            ThongBaoVM tbVM = new ThongBaoVM()
            {
                ThongBaoId = id,
                ThongBaoName = dBHelper.GetThongBaoByID(id).ThongBaoName
            };
            if (tbVM == null) return NotFound();
            else return View(tbVM);
        }
        [HttpPost]
        public IActionResult Delete(ThongBaoVM thongbaoVM)
        {

            {
                dBHelper.DeleteThongBao(thongbaoVM.ThongBaoId);
                return RedirectToAction("Index");
            }
            return View(thongbaoVM);
        }

        [HttpPost]
        public IActionResult Create(ThongBaoVM ThongBaoVM)
        {


            ThongBao thongbao = new ThongBao()
            {

                ThongBaoID = ThongBaoVM.ThongBaoId,
                ThongBaoName = ThongBaoVM.ThongBaoName,
                ThongTin = ThongBaoVM.ThongTin


            };
            dBHelper.InsertThongBao(thongbao);
            return RedirectToAction("Index");
        }
    }
}
