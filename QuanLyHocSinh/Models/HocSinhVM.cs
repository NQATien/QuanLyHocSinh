namespace QuanLyHocSinh.Models
{
    public class HocSinhVM
    {
        public int HocSinhId { get; set; }
        public string HocSinhName { get; set; }
        public string GioiTinh { get; set; }
        public int LopId { get; set; }
        public string LopName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
    }
}
