namespace QuanLyHocSinh.Models
{
    public class Mon
    {
        public int MonID { get; set; }
        public string MonName { get; set; }
        public int BoMonID { get; set; }
        public string BoMonName { get; set; }
        public int GiaoVienID { get; set; }
        public string GiaoVienName { get; set; }
        public BoMon BoMon { get; set; }
        public GiaoVien GiaoVien { get; set; }
    }
}
