namespace QuanLyHocSinh.Models
{
    public class GiaoVien
    {
        public int GiaoVienID { get; set; }
        public string GiaoVienName { get; set; }
        public string GioiTinh { get; set; }
        public int LopID { get; set; }
        public string LopName { get; set; }
        public Lop Lop { get; set; }
    }
}
