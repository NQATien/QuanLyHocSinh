namespace QuanLyHocSinh.Models
{
    public class HocSinh
    {
        public int HocSinhID { get; set; }
        public string HocSinhName { get; set; }
        public string ImagePath { get; set; }
        public string GioiTinh { get; set; }
        public int LopID { get; set; }
        public string LopName { get; set; }
        public Lop Lop { get; set; }
    }
}
