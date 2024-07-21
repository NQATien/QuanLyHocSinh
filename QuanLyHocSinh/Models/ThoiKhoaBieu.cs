namespace QuanLyHocSinh.Models
{
    public class ThoiKhoaBieu
    {
        public int ThoiKhoaBieuID { get; set; }
        public string ThoiKhoaBieuName { get; set; }
        public string GiaoVienName { get; set; }
        public string MonName { get; set; }
        public string Ngay { get; set; }
        public string Tiet { get; set; }
        public Lop Lop { get; set; }
    }
}