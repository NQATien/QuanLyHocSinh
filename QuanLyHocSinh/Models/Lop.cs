    namespace QuanLyHocSinh.Models
{
    public class Lop
    {
        public int LopID { get; set; }
        public string LopName { get; set; }
        public int SiSo { get; set; }
        public int KhoiID { get; set; }
        public string KhoiName { get; set; }
        public Khoi Khoi { get; set; }
    }
}
