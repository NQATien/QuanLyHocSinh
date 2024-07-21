using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.Models;

namespace QuanLyHocSinh.Controllers
{
    public class HocSinhController : Controller
    {
        DBHelper dBHelper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HocSinhController(StudentDbContext context, IWebHostEnvironment hostEnvironment)
        {
            
            dBHelper = new DBHelper(context);
            this._hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["listHocSinh"] = dBHelper.GetHocSinh();
            ViewData["ListLop"] = dBHelper.GetLop();
            return View();
        }

        [HttpPost]
        public IActionResult Index(int idLop)
        {
            ViewData["listHocSinh"] = dBHelper.GetHocSinh();
            ViewData["ListLop"] = dBHelper.GetLop();

            return View();
        }
        public IActionResult Detail(int ID)
        {
            ViewBag.HocSinhDetail = dBHelper.GetHocSinhByID(ID);
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            HocSinhVM hVM = new HocSinhVM()
            {
                HocSinhId = id,
                HocSinhName = dBHelper.GetHocSinhByID(id).HocSinhName
            };
            if (hVM == null) return NotFound();
            else return View(hVM);
        }
        [HttpPost]
        public IActionResult Edit(HocSinhVM hocsinhVM, IFormFile imageFile)
        {
            if (hocsinhVM.ImageFile != null && hocsinhVM.ImageFile.Length > 0)
            {

                var uploadFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "uploads");


                // Đặt tên cho file ảnh 
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                var filePath = Path.Combine(uploadFolderPath, uniqueFileName);

                // Lưu file ảnh vào thư mục trên máy chủ
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Lưu đường dẫn của file ảnh vào model
                hocsinhVM.ImagePath = uniqueFileName;
            }

            {
                HocSinh newHocsinh = new HocSinh()
                {
                    HocSinhID = hocsinhVM.HocSinhId,
                    HocSinhName = hocsinhVM.HocSinhName,
                    GioiTinh = hocsinhVM.GioiTinh,
                    LopID = hocsinhVM.LopId,
                    LopName = hocsinhVM.LopName,
                    ImagePath = hocsinhVM.ImagePath

                };
                dBHelper.EditHocSinh(newHocsinh);
                return RedirectToAction("Index");
            }
            return View(hocsinhVM);
        }

        public IActionResult Delete(int id)
        {
            HocSinhVM hVM = new HocSinhVM()
            {
                HocSinhId = id,
                HocSinhName = dBHelper.GetHocSinhByID(id).HocSinhName
            };
            if (hVM == null) return NotFound();
            else return View(hVM);
        }
        [HttpPost]
        public IActionResult Delete(HocSinhVM hocsinhVM)
        {

            {
                dBHelper.DeleteHocSinh(hocsinhVM.HocSinhId);
                return RedirectToAction("Index");
            }
            return View(hocsinhVM);
        }

        [HttpPost]
        public IActionResult Create(HocSinhVM hocsinhVM, IFormFile imageFile)
        {
            if (hocsinhVM.ImageFile != null && hocsinhVM.ImageFile.Length > 0)
            {

                var uploadFolderPath = Path.Combine(_hostEnvironment.WebRootPath, "uploads");


                // Đặt tên cho file ảnh 
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                var filePath = Path.Combine(uploadFolderPath, uniqueFileName);

                // Lưu file ảnh vào thư mục trên máy chủ
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Lưu đường dẫn của file ảnh vào model
                hocsinhVM.ImagePath = uniqueFileName;
            }

            HocSinh hocsinh = new HocSinh()
            {
                
                HocSinhName = hocsinhVM.HocSinhName,
                GioiTinh = hocsinhVM.GioiTinh,
                LopID = hocsinhVM.LopId,
                LopName = hocsinhVM.LopName,
                ImagePath = hocsinhVM.ImagePath // Lưu đường dẫn của file ảnh 
            };
            dBHelper.InsertHocSinh(hocsinh);
            return RedirectToAction("Index");
        }
        public ActionResult Search(int idlop)
        {
            if (idlop == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<HocSinh> locHS = dBHelper.LocKhoiHocSinh(idlop);
                return View("Search", locHS);
            }
            
        }

    }
}

