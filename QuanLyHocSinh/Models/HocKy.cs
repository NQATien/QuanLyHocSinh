namespace QuanLyHocSinh.Models
{
    public class HocKy
    {
        public int HocKyID { get; set; }
        public string HocKyName { get; set; }
        public int NamHocID { get; set; }
        public string NamHocName { get; set; }
        public NamHoc NamHoc { get; set; }
    }
}
